// VC_POSTEK_PRINTDlg.h : header file
//

#if !defined(AFX_VC_POSTEK_PRINTDLG_H__B4D19589_8BA0_4313_91CA_9BF21EDC4C24__INCLUDED_)
#define AFX_VC_POSTEK_PRINTDLG_H__B4D19589_8BA0_4313_91CA_9BF21EDC4C24__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CVC_POSTEK_PRINTDlg dialog

class CVC_POSTEK_PRINTDlg : public CDialog
{
// Construction
public:
	CVC_POSTEK_PRINTDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CVC_POSTEK_PRINTDlg)
	enum { IDD = IDD_VC_POSTEK_PRINT_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CVC_POSTEK_PRINTDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CVC_POSTEK_PRINTDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnPostekPrint();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_VC_POSTEK_PRINTDLG_H__B4D19589_8BA0_4313_91CA_9BF21EDC4C24__INCLUDED_)
