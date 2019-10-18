using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SharpConfig;

namespace ACM
{
    public partial class Demo : Form
    {
        // 按文件名称加载配置文件
        private Configuration loadConfig = Configuration.LoadFromFile(Application.StartupPath + "\\example.ini");
        //Configuration config = Configuration.LoadFromBinaryFile(Application.StartupPath + "\\myConfig.cfg")
        //config.SaveToBinaryFile(Application.StartupPath + "\\myConfig.cfg"); // 保存到cfg格式的二进制文件
        private Configuration saveConfig = new Configuration();

        public Demo()
        {
            InitializeComponent();
        }

        private void btnLoadValue_Click(object sender, EventArgs e)
        {
            Section section = loadConfig["General"];
            string someString = section["SomeString"].StringValue;
            int someInteger = section["SomeInteger"].IntValue;
            float someFloat = section["SomeFloat"].FloatValue;
            bool someBool = section["SomeBoolean"].BoolValue;
            //int someInteger = section["SomeInteger"].GetValue<int>();
            //float someFloat = section["SomeFloat"].GetValue<float>();
            //bool someBool = section["SomeBoolean"].GetValue<bool>();
            DayOfWeek day = section["Day"].GetValue<DayOfWeek>();
            Console.WriteLine("当前节名称:{0}", section.Name);
            Console.WriteLine("SomeString:{0}", someString);
            Console.WriteLine("someInteger:{0}", someInteger);
            Console.WriteLine("someFloat:{0}", someFloat);
            Console.WriteLine("someBool:{0}", someBool);
            Console.WriteLine("day:{0}", day);
        }

        private void btnLoadArray_Click(object sender, EventArgs e)
        {
            int[] someIntArray = loadConfig["General"]["SomeArray"].IntValueArray;

            foreach (int i in someIntArray)
            {
                Console.Write("{0} ", i);
            }

            Console.Write("\r\n");
        }

        private void btnLoadClass_Click(object sender, EventArgs e)
        {
            Person person = loadConfig["Person"].ToObject<Person>();
            Console.WriteLine("name:{0}, age:{1}", person.Name, person.Age);
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            [SharpConfig.Ignore]
            public int SomeInt { get; set; }
        }

        private void btnSaveValue_Click(object sender, EventArgs e)
        {
            //Configuration saveConfig = new Configuration(); // 若文件已存在，则会覆盖
            saveConfig["Video"]["Width"].IntValue = 1920;
            saveConfig["Video"]["Height"].IntValue = 1080;
            saveConfig.SaveToFile("myConfig.cfg");
        }

        private void btnSaveArray_Click(object sender, EventArgs e)
        {
            saveConfig["Video"]["Formats"].StringValueArray = new[] { "RGB32", "RGBA32" };
            saveConfig.SaveToFile("myConfig.cfg");
        }

        private void btnSaveClass_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            saveConfig["Person"]["Name"].StringValue = "LX";
            saveConfig["Person"]["Age"].IntValue = 27;
            saveConfig["Person"]["SomeInt"].IntValue = 999;
            saveConfig.SaveToFile("myConfig.cfg");
            
            Person p2 = null;// = new Person();
            Configuration myConfig = Configuration.LoadFromFile("myConfig.cfg");
            p2 = myConfig["Person"].ToObject<Person>(); // 会新建一个对象
            myConfig["Person"].SetValuesTo(p2); // 赋值属性给已有的对象
        }
    }
}
