// VC_POSTEK_PRINTDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC_POSTEK_PRINT.h"
#include "VC_POSTEK_PRINTDlg.h"
#include "PTKPRN.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CVC_POSTEK_PRINTDlg dialog

CVC_POSTEK_PRINTDlg::CVC_POSTEK_PRINTDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CVC_POSTEK_PRINTDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CVC_POSTEK_PRINTDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CVC_POSTEK_PRINTDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CVC_POSTEK_PRINTDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CVC_POSTEK_PRINTDlg, CDialog)
	//{{AFX_MSG_MAP(CVC_POSTEK_PRINTDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDOK, OnPostekPrint)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CVC_POSTEK_PRINTDlg message handlers

BOOL CVC_POSTEK_PRINTDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CVC_POSTEK_PRINTDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CVC_POSTEK_PRINTDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CVC_POSTEK_PRINTDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CVC_POSTEK_PRINTDlg::OnPostekPrint() 
{
	HINSTANCE gt1 = NULL;
	
	gt1=LoadLibrary("WINPSK.dll");
	OpenPort = (fOpenPort)GetProcAddress(gt1,"OpenPort");
    ClosePort = (fClosePort)GetProcAddress(gt1,"ClosePort");
	PTK_DrawBarcode = (fPTK_DrawBarcode)GetProcAddress(gt1,"PTK_DrawBarcode");
    PTK_SetLabelHeight = (fPTK_SetLabelHeight)GetProcAddress(gt1,"PTK_SetLabelHeight");
    PTK_PrintLabel = (fPTK_PrintLabel)GetProcAddress(gt1,"PTK_PrintLabel");
    PTK_SetDarkness = (fPTK_SetDarkness)GetProcAddress(gt1,"PTK_SetDarkness");
    PTK_SetPrintSpeed = (fPTK_SetPrintSpeed)GetProcAddress(gt1,"PTK_SetPrintSpeed");
	PTK_SetLabelWidth = (fPTK_SetLabelWidth)GetProcAddress(gt1,"PTK_SetLabelWidth");
    PTK_ClearBuffer = (fPTK_ClearBuffer)GetProcAddress(gt1,"PTK_ClearBuffer");
	PTK_DrawTextTrueTypeW = (fPTK_DrawTextTrueTypeW)GetProcAddress(gt1,"PTK_DrawTextTrueTypeW");
	PTK_DrawLineOr = (fPTK_DrawLineOr)GetProcAddress(gt1,"PTK_DrawLineOr");
	PTK_DrawText = (fPTK_DrawText)GetProcAddress(gt1,"PTK_DrawText");
	PTK_DrawBar2D_QR = (fPTK_DrawBar2D_QR)GetProcAddress(gt1,"PTK_DrawBar2D_QR");
	PTK_DrawBar2D_Pdf417 = (fPTK_DrawBar2D_Pdf417)GetProcAddress(gt1,"PTK_DrawBar2D_Pdf417");
	PTK_PcxGraphicsDel  = (fPTK_PcxGraphicsDel)GetProcAddress(gt1,"PTK_PcxGraphicsDel");
	PTK_PcxGraphicsDownload = (fPTK_PcxGraphicsDownload)GetProcAddress(gt1,"PTK_PcxGraphicsDownload");
	PTK_DrawPcxGraphics = (fPTK_DrawPcxGraphics)GetProcAddress(gt1,"PTK_DrawPcxGraphics");
	PTK_DrawRectangle  = (fPTK_DrawRectangle)GetProcAddress(gt1,"PTK_DrawRectangle");
	
	int i1;
	int errorcode = 0;

	OpenPort("POSTEK G-2108");

	for (i1=0;i1<1;i1++)
	 {
		errorcode=PTK_ClearBuffer();  	 
		if (errorcode!=0)  {break;}
		errorcode = PTK_SetLabelHeight (600,16,0,false);      // 设置标签的高度和行间隙大小；
		if(errorcode != 0) {break;}
		errorcode = PTK_SetLabelWidth (800);          // 设置标签的宽度；
		if(errorcode != 0) {break;}
        errorcode = PTK_SetDarkness( 10 );            // 设置打印机打印温度;
		if(errorcode != 0) {break;}
        errorcode = PTK_SetPrintSpeed( 5 );           // 设置打印机打印速度;

    	// 画矩形
        errorcode = PTK_DrawRectangle(58,15,3,558,312);
		if(errorcode != 0) {break;}

        // 打印PCX图片 方式一
        errorcode = PTK_PcxGraphicsDel("PCX");
		if(errorcode != 0) {break;}
        errorcode = PTK_PcxGraphicsDownload("PCX","logo.pcx");
		if(errorcode != 0) {break;}
        errorcode = PTK_DrawPcxGraphics(80,20,"PCX");
		if(errorcode != 0) {break;}

         // 打印PCX图片 方式二
       // PTK_PrintPCX(80,30,pchar('logo.pcx'));


        // 打印一个条码;
        errorcode = PTK_DrawBarcode(300, 23, 0, "1", 2, 2, 50, 'B', "123456789");
		if(errorcode != 0) {break;}

        // 画表格分割线
        errorcode = PTK_DrawLineOr(58,100,500,3);
		if(errorcode != 0) {break;}

        // 打印一行TrueTypeFont文字;
        errorcode = PTK_DrawTextTrueTypeW (80, 120, 40, 0, "Arial", 1, 400, 0, 0, 0, "A1", "TrueTypeFont");
		if(errorcode != 0) {break;}

        // 打印一行文本文字(内置字体或软字体);
        errorcode = PTK_DrawText(80, 168, 0, 3, 1, 1, 'N', "Internal Soft Font");
		if(errorcode != 0) {break;}

        // 打印PDF417码
        errorcode = PTK_DrawBar2D_Pdf417(80,210,400,300,0,0,3,7,10,2,0,0,"123456789");//PDF417码
		if(errorcode != 0) {break;}

        // 打印QR码
        errorcode = PTK_DrawBar2D_QR(420,120,180,180,0,3,2,0,0, "Postek Electronics Co., Ltd.");
		if(errorcode != 0) {break;}

        // 打印一行TrueTypeFont文字旋转;

        errorcode = PTK_DrawTextTrueTypeW(520, 102, 22, 0, "Arial", 2, 400, 0, 0, 0, "A2", "www.postek.com.cn");
		if(errorcode != 0) {break;}
        errorcode = PTK_DrawTextTrueTypeW(80, 260, 19, 0, "Arial", 1, 700, 0, 0, 0, "A3", "Use different ID_NAME for different Truetype font objects");
		if(errorcode != 0) {break;}

        // 命令打印机执行打印工作
		errorcode=PTK_PrintLabel(1,1);
		if (errorcode!=0)  {break;}	
	}
    
    ClosePort();
	
    
	FreeLibrary(gt1);
 
	
}
