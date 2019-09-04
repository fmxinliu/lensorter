#pragma once

#include "gtsmotionclass.h"
#include <msclr\marshal_cppstd.h>
#include <iostream>
#include <tchar.h>

namespace MotionControl {

    using namespace System;
    using namespace System::ComponentModel;
    using namespace System::Collections;
    using namespace System::Windows::Forms;
    using namespace System::Data;
    using namespace System::Drawing;
    using namespace msclr::interop;
    using namespace System::Runtime::InteropServices;


    /// <summary>
    /// Test 摘要
    /// </summary>
    public ref class Test : public System::Windows::Forms::Form
    {
    public:
        Test(void)
        {
            InitializeComponent();
            //
            //TODO: 在此处添加构造函数代码
            //

            gts = new GTSMotionClass();

            cbxSelectCard->SelectedIndex = 0;
            cbxSelectAxis->SelectedIndex = 0;
            tbxVel->Text = "1";
            tbxAcc->Text = "0.1";
            tbxDec->Text = "0.1";
        }

        int StringToInt(String ^s);
        double StringToDouble(String ^s);
        const char* StringToChars(String ^s);

    protected:
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        ~Test()
        {
            if (components)
            {
                delete components;
            }

            delete gts;
        }

    private: GTSMotionClass *gts;
    private: System::Windows::Forms::Button^  btnClose; 
    private: System::Windows::Forms::Button^  btnOpen;
    private: System::Windows::Forms::TextBox^  tbxVel;
    private: System::Windows::Forms::Label^  label4;
    private: System::Windows::Forms::TextBox^  tbxDec;
    private: System::Windows::Forms::Label^  label3;
    private: System::Windows::Forms::TextBox^  tbxAcc;
    private: System::Windows::Forms::Label^  label2;
    private: System::Windows::Forms::Button^  btnJogN;
    private: System::Windows::Forms::Button^  btnJogP;
    private: System::Windows::Forms::Label^  label;
    private: System::Windows::Forms::ComboBox^  cbxSelectAxis;
    private: System::Windows::Forms::Label^  label1;
    private: System::Windows::Forms::ComboBox^  cbxSelectCard;



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
            this->btnClose = (gcnew System::Windows::Forms::Button());
            this->btnOpen = (gcnew System::Windows::Forms::Button());
            this->tbxVel = (gcnew System::Windows::Forms::TextBox());
            this->label4 = (gcnew System::Windows::Forms::Label());
            this->tbxDec = (gcnew System::Windows::Forms::TextBox());
            this->label3 = (gcnew System::Windows::Forms::Label());
            this->tbxAcc = (gcnew System::Windows::Forms::TextBox());
            this->label2 = (gcnew System::Windows::Forms::Label());
            this->btnJogN = (gcnew System::Windows::Forms::Button());
            this->btnJogP = (gcnew System::Windows::Forms::Button());
            this->label = (gcnew System::Windows::Forms::Label());
            this->cbxSelectAxis = (gcnew System::Windows::Forms::ComboBox());
            this->label1 = (gcnew System::Windows::Forms::Label());
            this->cbxSelectCard = (gcnew System::Windows::Forms::ComboBox());
            this->SuspendLayout();
            // 
            // btnClose
            // 
            this->btnClose->Location = System::Drawing::Point(397, 37);
            this->btnClose->Name = L"btnClose";
            this->btnClose->Size = System::Drawing::Size(75, 23);
            this->btnClose->TabIndex = 43;
            this->btnClose->Text = L"关闭";
            this->btnClose->UseVisualStyleBackColor = true;
            this->btnClose->Click += gcnew System::EventHandler(this, &Test::btnClose_Click);
            // 
            // btnOpen
            // 
            this->btnOpen->Location = System::Drawing::Point(288, 37);
            this->btnOpen->Name = L"btnOpen";
            this->btnOpen->Size = System::Drawing::Size(75, 23);
            this->btnOpen->TabIndex = 42;
            this->btnOpen->Text = L"打开";
            this->btnOpen->UseVisualStyleBackColor = true;
            this->btnOpen->Click += gcnew System::EventHandler(this, &Test::btnOpen_Click);
            // 
            // tbxVel
            // 
            this->tbxVel->Location = System::Drawing::Point(105, 244);
            this->tbxVel->Name = L"tbxVel";
            this->tbxVel->Size = System::Drawing::Size(100, 25);
            this->tbxVel->TabIndex = 41;
            // 
            // label4
            // 
            this->label4->AutoSize = true;
            this->label4->Location = System::Drawing::Point(35, 251);
            this->label4->Name = L"label4";
            this->label4->Size = System::Drawing::Size(37, 15);
            this->label4->TabIndex = 40;
            this->label4->Text = L"速度";
            // 
            // tbxDec
            // 
            this->tbxDec->Location = System::Drawing::Point(105, 200);
            this->tbxDec->Name = L"tbxDec";
            this->tbxDec->Size = System::Drawing::Size(100, 25);
            this->tbxDec->TabIndex = 39;
            // 
            // label3
            // 
            this->label3->AutoSize = true;
            this->label3->Location = System::Drawing::Point(35, 207);
            this->label3->Name = L"label3";
            this->label3->Size = System::Drawing::Size(52, 15);
            this->label3->TabIndex = 38;
            this->label3->Text = L"减速度";
            // 
            // tbxAcc
            // 
            this->tbxAcc->Location = System::Drawing::Point(105, 156);
            this->tbxAcc->Name = L"tbxAcc";
            this->tbxAcc->Size = System::Drawing::Size(100, 25);
            this->tbxAcc->TabIndex = 37;
            // 
            // label2
            // 
            this->label2->AutoSize = true;
            this->label2->Location = System::Drawing::Point(35, 163);
            this->label2->Name = L"label2";
            this->label2->Size = System::Drawing::Size(52, 15);
            this->label2->TabIndex = 36;
            this->label2->Text = L"加速度";
            // 
            // btnJogN
            // 
            this->btnJogN->Location = System::Drawing::Point(397, 87);
            this->btnJogN->Name = L"btnJogN";
            this->btnJogN->Size = System::Drawing::Size(75, 23);
            this->btnJogN->TabIndex = 35;
            this->btnJogN->Text = L"Jog-";
            this->btnJogN->UseVisualStyleBackColor = true;
            this->btnJogN->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Test::btnJog_MouseDown);
            this->btnJogN->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Test::btnJog_MouseUp);
            // 
            // btnJogP
            // 
            this->btnJogP->Location = System::Drawing::Point(288, 87);
            this->btnJogP->Name = L"btnJogP";
            this->btnJogP->Size = System::Drawing::Size(75, 23);
            this->btnJogP->TabIndex = 34;
            this->btnJogP->Text = L"Jog+";
            this->btnJogP->UseVisualStyleBackColor = true;
            this->btnJogP->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Test::btnJog_MouseDown);
            this->btnJogP->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Test::btnJog_MouseUp);
            // 
            // label
            // 
            this->label->AutoSize = true;
            this->label->Location = System::Drawing::Point(35, 91);
            this->label->Name = L"label";
            this->label->Size = System::Drawing::Size(22, 15);
            this->label->TabIndex = 33;
            this->label->Text = L"轴";
            // 
            // cbxSelectAxis
            // 
            this->cbxSelectAxis->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
            this->cbxSelectAxis->FormattingEnabled = true;
            this->cbxSelectAxis->Items->AddRange(gcnew cli::array< System::Object^  >(8) {L"1", L"2", L"3", L"4", L"5", L"6", L"7", L"8"});
            this->cbxSelectAxis->Location = System::Drawing::Point(84, 87);
            this->cbxSelectAxis->Name = L"cbxSelectAxis";
            this->cbxSelectAxis->Size = System::Drawing::Size(121, 23);
            this->cbxSelectAxis->TabIndex = 32;
            // 
            // label1
            // 
            this->label1->AutoSize = true;
            this->label1->Location = System::Drawing::Point(35, 41);
            this->label1->Name = L"label1";
            this->label1->Size = System::Drawing::Size(22, 15);
            this->label1->TabIndex = 31;
            this->label1->Text = L"卡";
            // 
            // cbxSelectCard
            // 
            this->cbxSelectCard->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
            this->cbxSelectCard->FormattingEnabled = true;
            this->cbxSelectCard->Items->AddRange(gcnew cli::array< System::Object^  >(2) {L"GTS-400", L"GTS-800"});
            this->cbxSelectCard->Location = System::Drawing::Point(84, 37);
            this->cbxSelectCard->Name = L"cbxSelectCard";
            this->cbxSelectCard->Size = System::Drawing::Size(121, 23);
            this->cbxSelectCard->TabIndex = 30;
            // 
            // Test
            // 
            this->AutoScaleDimensions = System::Drawing::SizeF(8, 15);
            this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
            this->ClientSize = System::Drawing::Size(515, 406);
            this->Controls->Add(this->btnClose);
            this->Controls->Add(this->btnOpen);
            this->Controls->Add(this->tbxVel);
            this->Controls->Add(this->label4);
            this->Controls->Add(this->tbxDec);
            this->Controls->Add(this->label3);
            this->Controls->Add(this->tbxAcc);
            this->Controls->Add(this->label2);
            this->Controls->Add(this->btnJogN);
            this->Controls->Add(this->btnJogP);
            this->Controls->Add(this->label);
            this->Controls->Add(this->cbxSelectAxis);
            this->Controls->Add(this->label1);
            this->Controls->Add(this->cbxSelectCard);
            this->Name = L"Test";
            this->Text = L"运动卡调试";
            this->ResumeLayout(false);
            this->PerformLayout();

        }
#pragma endregion
    private: System::Void btnOpen_Click(System::Object^  sender, System::EventArgs^  e) {
                 
                 gts->SetCardNo(cbxSelectCard->SelectedIndex);
                 gts->OpenCard();
                 std::string path = cbxSelectCard->SelectedIndex ? "D:\\GTS800.cfg" : "D:\\GTS400.cfg";
                 //gts->LoadConfig(path);
             }
    private: System::Void btnClose_Click(System::Object^  sender, System::EventArgs^  e) {
                
                 gts->SetCardNo(cbxSelectCard->SelectedIndex); // 切换卡
                 gts->CloseCard();
             }
    private: System::Void btnJog_MouseDown(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
         
                 Button^ button = (Button ^)sender;
                 int nAixID = cbxSelectAxis->SelectedIndex;
                 int nSpeed = StringToInt(tbxVel->Text);
                 double nACC = StringToDouble(tbxAcc->Text);
                 double nDEC = StringToDouble(tbxDec->Text);
                 double nSmooth = 0.1;

                 gts->AixOn(nAixID);
                 if (button->Name == "正向") {
                     gts->JogMove(nAixID, nSpeed, nACC, nDEC, nSmooth);
                 }
                 else {
                     gts->JogMove(nAixID, -1 * nSpeed, nACC, nDEC, nSmooth);
                 }
             }
    private: System::Void btnJog_MouseUp(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
                gts->StopMove(cbxSelectAxis->SelectedIndex, 0);
             }
};
}
