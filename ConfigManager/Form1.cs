using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpConfig;

namespace ConfigManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test1();
        }

        static void Test1()
        {
            //按文件名称加载配置文件
            Configuration config = Configuration.LoadFromFile(Application.StartupPath + "\\example.ini");
            //Configuration config = Configuration.LoadFromBinaryFile(Application.StartupPath + "\\myConfig.cfg")
            //config.SaveToBinaryFile(Application.StartupPath + "\\myConfig.cfg"); // 保存到cfg格式的二进制文件

            //按照节的名称读取节
            Section section = config["General"];
            //依次根据每个配置项的名称来读取，如果配置文件类型搞错了，会报错
            string someString = section["SomeString"].StringValue;
            var someInteger = section["SomeInteger"].GetValue<int>();
            float someFloat = section["SomeFloat"].GetValue<float>();
            Boolean someBool = section["ABoolean"].GetValue<bool>();
            Console.WriteLine("当前节名称:{0}", section.Name);
            Console.WriteLine("SomeString:{0}", someString);
            Console.WriteLine("someInteger:{0}", someInteger);
            Console.WriteLine("someFloat:{0}", someFloat);
            Console.WriteLine("someBool:{0}", someBool);

            int[] someIntArray = section["SomeArray"].IntValueArray;
            Person person = config["Person"].ToObject<Person>();
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
