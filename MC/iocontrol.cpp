#include "StdAfx.h"
#include "iocontrol.h"
#include <tchar.h>

using namespace MC;

void IOControl::InitControl(System::Windows::Forms::GroupBox^ gbx, String^ iotype)
{
    for (int i = 0; i < IOCOUNT_PER_MDL; i++) {
        System::Windows::Forms::Label^ lblIO = gcnew System::Windows::Forms::Label();
        lblIO->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
        lblIO->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
        lblIO->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
        lblIO->Location = System::Drawing::Point(30 + i % 8 * 38, 30 + i / 8 * 38);
        lblIO->Size = System::Drawing::Size(32, 32);
        lblIO->Name = iotype + (i + 1);
        lblIO->Text = (i + 1).ToString();
        gbx->Controls->Add(lblIO);

        if (iotype == L"lblOutput") {
            lblIO->Click += gcnew System::EventHandler(this, &IOControl::lblIO_Click);
        }

        selectedCard = selectedMdl = 0;
        cbxSelectCard->SelectedIndex = 0;
        cbxSelectMdl->SelectedIndex = 0;
    }
}

System::Void IOControl::btnOpen_Click(System::Object^ sender, System::EventArgs^ e)
{
    bool ret = false;
    if (cbxSelectCard->Text == L"GTS-400") {
        ret = gts400->OpenCard();
    } else {
        ret = gts800->OpenCard();
    }

    // 启动刷新定时器
    if (!timerRefresh->Enabled) {
        timerRefresh->Enabled = true;
    }

    // 提示
    if (ret) {
        ResetMdl();
        btnOpen->Enabled = false;
    } else {
        System::Windows::Forms::MessageBox::Show(this, L"打开失败");
    }
}

System::Void IOControl::btnClose_Click(System::Object^ sender, System::EventArgs^ e)
{
    ResetMdl();
    if (cbxSelectCard->Text == L"GTS-400") {
        gts400->CloseCard();
    } else {
        gts800->CloseCard();
    }

    btnOpen->Enabled = true;
}

System::Void IOControl::cbxSelectCard_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
{
    if (selectedCard != cbxSelectCard->SelectedIndex) {
        selectedCard = cbxSelectCard->SelectedIndex;
    }
}

System::Void IOControl::cbxSelectMdl_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
{
    if (selectedMdl != cbxSelectMdl->SelectedIndex) {
        selectedMdl = cbxSelectMdl->SelectedIndex;
    }
}

System::Void IOControl::lblIO_Click(System::Object^ sender, System::EventArgs^ e)
{
    int mdl = GetMdl();
    GTSMotionProxy^ gts = GtsControl();

    Label^ lblOutput = (Label ^)sender;
    int index = StringToInt(lblOutput->Text) - 1;
    bool value = (lblOutput->BackColor != Color::Green) ? true : false;

    if (mdl != -1) {
        bool ret = gts->SetDo(mdl, index, value);
        if (ret) {
            pMdlIOBuffer[mdl] &= ~(1 << index);
            pMdlIOBuffer[mdl] |= value << index;
        }
        value = ret ? value : !value;
    } else {
        value = gts->SetDo(index, value) ? value : !value;
    }

    lblOutput->BackColor = value ? Color::Green : SystemColors::Control;
}

System::Void IOControl::timerRefresh_Tick(System::Object^ sender, System::EventArgs^ e)
{
    timerRefresh->Stop();
    RefreshInput();
    RefreshOutput();
    timerRefresh->Start();
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

GTSMotionProxy^ IOControl::GtsControl()
{
    GTSMotionProxy^ gts = (cbxSelectCard->Text == L"GTS-400") ? gts400 : gts800;
    return gts;
}

int IOControl::GetMdl()
{
    int mdl = selectedMdl ? selectedMdl - 1 : -1;
    return mdl;
}

void IOControl::RefreshInput()
{
    int mdl = GetMdl();
    GTSMotionProxy^ gts = GtsControl();

    for (int i = 0; i < gbxInput->Controls->Count; i++) {
        Label^ lblOutput = (Label ^)gbxInput->Controls[i];
        int index = StringToInt(lblOutput->Text) - 1;
        bool value = (mdl != -1) ? gts->ReadDi(mdl, index) : gts->ReadDi(index);
        lblOutput->BackColor = value ? Color::Green : SystemColors::Control;
    }
}

void IOControl::RefreshOutput()
{
    int mdl = GetMdl();
    GTSMotionProxy^ gts = GtsControl();

    for (int i = 0; i < gbxOutput->Controls->Count; i++) {
        Label^ lblOutput = (Label ^)gbxOutput->Controls[i];
        int index = StringToInt(lblOutput->Text) - 1;
        bool value = (mdl == -1) ? gts->ReadDo(index) : (pMdlIOBuffer[mdl] & (1 << index)) ? true : false;
        lblOutput->BackColor = value ? Color::Green : SystemColors::Control;
    }
}

void IOControl::ResetMdl()
{
    int mdl = GetMdl();
    GTSMotionProxy^ gts = GtsControl();

    // 复位 IO
    for (int i = 0; i < GTS_400_MDLNUM; i++) {
        gts->SetDo(i, 0xffff);
    }

    // 复位显示
    if (mdl != -1) {
        for (int i = 0; i < IOCOUNT_PER_MDL; i++) {
            Label^ lblOutput = (Label ^)gbxOutput->Controls[i];
            int index = StringToInt(lblOutput->Text) - 1;
            lblOutput->BackColor = SystemColors::Control;
        }
    }

    // 复位扩展 IO 缓存
    memset(pMdlIOBuffer, 0, sizeof(int) * mdlNum);
}
