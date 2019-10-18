#include "StdAfx.h"
#include "iocontrol.h"
#include <tchar.h>

#define COUNT 16
using namespace MC;

void IOControl::InitControl(System::Windows::Forms::GroupBox^ gbx, String^ iotype)
{
    for (int i = 0; i < COUNT; i++) {
        System::Windows::Forms::Label^ lblIO = gcnew System::Windows::Forms::Label();
        lblIO->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
        lblIO->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
        lblIO->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
        lblIO->Location = System::Drawing::Point(30 + i % 8 * 38, 30 + i / 8 * 38);
        lblIO->Size = System::Drawing::Size(32, 32);
        lblIO->Name = iotype + (i + 1);
        lblIO->Text = i.ToString();
        gbx->Controls->Add(lblIO);

        if (iotype == L"lblOutput") {
            lblIO->Click += gcnew System::EventHandler(this, &IOControl::lblIO_Click);
        }
    }
}

System::Void IOControl::btnOpen_Click(System::Object^ sender, System::EventArgs^ e)
{
    if (cbxSelectCard->Text == L"GTS-400") {
        gts400->OpenCard();
    } else {
        gts800->OpenCard();
    }

    if (!timerRefresh->Enabled) {
        timerRefresh->Enabled = true;
    }
}

System::Void IOControl::btnClose_Click(System::Object^ sender, System::EventArgs^ e)
{
    if (cbxSelectCard->Text == L"GTS-400") {
        gts400->CloseCard();
    } else {
        gts800->CloseCard();
    }
}

System::Void IOControl::cbxSelectCard_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
{
    if (selectedCard != cbxSelectCard->SelectedIndex) {
        selectedCard = cbxSelectCard->SelectedIndex;
        RefreshOutput();
    }
}

System::Void IOControl::cbxSelectMdl_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
{
    if (selectedMdl != cbxSelectMdl->SelectedIndex) {
        selectedMdl = cbxSelectMdl->SelectedIndex;
        RefreshOutput();
    }
}

System::Void IOControl::lblIO_Click(System::Object^ sender, System::EventArgs^ e)
{
    int mdl = getMdl();
    GTSMotionProxy^ gts = gtsControl();

    Label^ lblOutput = (Label ^)sender;
    int index = StringToInt(lblOutput->Text);
    bool value = (lblOutput->BackColor != Color::Green) ? true : false;
    
    if (mdl != -1) {
        value = gts->SetDo(mdl, index, value) ? value : !value;
    } else {
        value = gts->SetDo(index, value) ? value : !value;
    }

    lblOutput->BackColor = value ? Color::Green : SystemColors::Control;
}

int IOControl::StringToInt(String ^s)
{
    // marshal_as当返回的对象需要显式内存清理时，就需要基于marshal_context上下文的封送了
    marshal_context ^mc = gcnew marshal_context();
    const char* str = mc->marshal_as<const char*>(s);
    int value = _ttoi(str);
    delete mc;  // 当marshal_context删除后，任何在封送调用期间分配的内存都将被释放
    return value;
}

GTSMotionProxy^ IOControl::gtsControl()
{
    GTSMotionProxy^ gts = (cbxSelectCard->Text == L"GTS-400") ? gts400 : gts800;
    return gts;
}

int IOControl::getMdl()
{
    int mdl = selectedMdl ? selectedMdl - 1 : -1;
    return mdl;
}

void IOControl::RefreshInput()
{
    int mdl = getMdl();
    GTSMotionProxy^ gts = gtsControl();
    
    for (int i = 0; i < gbxInput->Controls->Count; i++) {
        Label^ lblOutput = (Label ^)gbxInput->Controls[i];
        int index = StringToInt(lblOutput->Text);
        bool value = (mdl != -1) ? gts->ReadDi(mdl, index) : gts->ReadDi(index);
        lblOutput->BackColor = value ? Color::Green : SystemColors::Control;
    }
}

void IOControl::RefreshOutput()
{
    int mdl = getMdl();
    GTSMotionProxy^ gts = gtsControl();

    for (int i = 0; i < gbxOutput->Controls->Count; i++) {
        Label^ lblOutput = (Label ^)gbxOutput->Controls[i];
        int index = StringToInt(lblOutput->Text);
        bool value = (mdl != -1) ? false : gts->ReadDo(index);
        lblOutput->BackColor = value ? Color::Green : SystemColors::Control;
    }
}

System::Void IOControl::timerRefresh_Tick(System::Object^ sender, System::EventArgs^ e)
{
    timerRefresh->Stop();
    RefreshInput();
    timerRefresh->Start();
}
