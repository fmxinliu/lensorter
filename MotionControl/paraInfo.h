#pragma once

#using "..\bin\Debug\\CCL.dll"

namespace MotionControl {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
    using namespace CCL;

	/// <summary>
	/// Form1 摘要
	/// </summary>
	public ref class ParaInfo : public System::Windows::Forms::Form
	{
	public:
		ParaInfo(void)
		{
			InitializeComponent();
			//
			//TODO: 在此处添加构造函数代码
			//
		}

	protected:
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		~ParaInfo()
		{
			if (components)
			{
				delete components;
			}
        }
    private: CCL::RowMergeView^  dataGridView1;

    protected: 

	private:
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		void InitializeComponent(void)
		{
            this->SuspendLayout();
            // 
            // ParaInfo
            // 
            this->ClientSize = System::Drawing::Size(282, 255);
            this->Name = L"ParaInfo";
            this->ResumeLayout(false);

        }
#pragma endregion

    };
}

