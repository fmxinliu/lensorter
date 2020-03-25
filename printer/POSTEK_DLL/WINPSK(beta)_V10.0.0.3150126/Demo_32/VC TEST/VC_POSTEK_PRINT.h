// VC_POSTEK_PRINT.h : main header file for the VC_POSTEK_PRINT application
//

#if !defined(AFX_VC_POSTEK_PRINT_H__99F643AA_E61B_4A2A_88EF_DC0EE3026D23__INCLUDED_)
#define AFX_VC_POSTEK_PRINT_H__99F643AA_E61B_4A2A_88EF_DC0EE3026D23__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CVC_POSTEK_PRINTApp:
// See VC_POSTEK_PRINT.cpp for the implementation of this class
//

class CVC_POSTEK_PRINTApp : public CWinApp
{
public:
	CVC_POSTEK_PRINTApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CVC_POSTEK_PRINTApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CVC_POSTEK_PRINTApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_VC_POSTEK_PRINT_H__99F643AA_E61B_4A2A_88EF_DC0EE3026D23__INCLUDED_)
