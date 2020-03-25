//WINPSK.DLL函数声明头文件
#ifndef _PWINPSK_H
#define _PWINPSK_H

//WINPSK DLL Function Declaration start
typedef int (__stdcall *fOpenPort)(LPTSTR szPrinterName);
typedef int (__stdcall *fSetPCComPort)(DWORD BaudRate, BOOL HandShake);
typedef int (__stdcall *fClosePort)(void);
typedef int (__stdcall *fPTK_GetErrState)(void);
typedef int (__stdcall *fPTK_PrintLabel)(unsigned int number,
		                                 unsigned int cpnumber);
typedef int (_stdcall *fPTK_GetInfo)();
typedef int (__stdcall *fPTK_ClearBuffer)();
typedef int (__stdcall *fPTK_SetDarkness)(unsigned  int id);
typedef int (__stdcall *fPTK_SetPrintSpeed)(unsigned int px);
typedef int (__stdcall *fPTK_SetLabelHeight)(unsigned int lheight, unsigned int gapH,
											 int gapOffset,BOOL bFlag);
typedef int (__stdcall *fPTK_SetLabelWidth)(unsigned int lwidth);
typedef int (__stdcall *fPTK_SetDirection)(TCHAR direct);


typedef int (_stdcall *fPTK_DrawText)(unsigned  int px,unsigned int  py,
							  unsigned int  pdirec,unsigned int pFont,
							  unsigned int  pHorizontal,
							  unsigned int  pVertical,
							  TCHAR ptext,LPTSTR pstr);
typedef int (_stdcall *fPTK_DrawTextEx)(unsigned int px,unsigned int  py,
							unsigned int  pdirec,unsigned int pFont,
							unsigned int  pHorizontal,
							unsigned int  pVertical,
							TCHAR ptext,LPTSTR pstr, BOOL Varible);

typedef int (__stdcall *fPTK_DrawTextTrueTypeW)(int x,int y,unsigned  int FHeight,
								   unsigned  int FWidth, LPCTSTR FType,
								   unsigned  int Fspin,unsigned  int FWeight,BOOL FItalic,BOOL FUnline,
								   BOOL FStrikeOut,LPTSTR id_name,LPCTSTR data);


typedef int (__stdcall *fPTK_DrawBar2D_DATAMATRIX) ( unsigned int x, unsigned int y,
													unsigned int w, unsigned int v,
													unsigned int o, unsigned int m,
													LPTSTR pstr );

typedef int (__stdcall *fPTK_DrawBar2D_QR)(unsigned int x,unsigned int y,
										   unsigned int w, unsigned int v,
										   unsigned int o, unsigned int r,
										   unsigned int m, unsigned int g,
										   unsigned int s,LPTSTR pstr);

typedef int (__stdcall *fPTK_DrawBar2D_QREx)(unsigned int x, unsigned int y,
								             unsigned int o, unsigned int r,
							                 unsigned int g, unsigned int v,
							               	 unsigned int s, LPTSTR id_name, 
							              	 LPTSTR pstr);

typedef int (__stdcall *fPTK_DrawBar2D_MaxiCode)( unsigned int x, unsigned int y,
												 unsigned int m, unsigned int u,
												 LPTSTR pstr );
typedef int (_stdcall *fPTK_DrawBar2D_Pdf417)(unsigned int x, unsigned int  y,
								      unsigned int w, unsigned int v,
								      unsigned int s, unsigned int c,
									  unsigned int px, unsigned int  py,
									  unsigned int r, unsigned int l,
								      unsigned int t, unsigned int o,					   
								      LPTSTR pstr);

typedef int (__stdcall *fPTK_DrawBar2D_HANXIN)( unsigned int x, unsigned int y,
											   unsigned int w, unsigned int v,
											   unsigned int o, unsigned int r,
											   unsigned int m, unsigned int g,
											   unsigned int s,	LPTSTR pstr );

typedef int (__stdcall *fPTK_DrawBarcode)(unsigned  int px,
		                        unsigned int  py,
								unsigned int  pdirec,
								LPTSTR        pCode,
								unsigned int  pHorizontal,
								unsigned int  pVertical,
								unsigned int pbright,
								TCHAR ptext,
								LPTSTR pstr);

typedef int (__stdcall *fPTK_DrawBarcodeEx)(unsigned  int px,unsigned int  py,
							   unsigned int  pdirec,LPTSTR pCode,
							   unsigned int  NarrowWidth,
							   unsigned int  pHorizontal,
							   unsigned int  pVertical,					   
							   TCHAR ptext,LPTSTR pstr,BOOL Varible);

typedef int (__stdcall *fPTK_PcxGraphicsList)();
typedef int (__stdcall *fPTK_PcxGraphicsDel) (LPTSTR pid);
typedef int (__stdcall *fPTK_PcxGraphicsDownload) (TCHAR*  pcxname, TCHAR* pcxpath);
typedef int (__stdcall *fPTK_DrawPcxGraphics)(unsigned int  px, unsigned int  py, LPTSTR  gname);
typedef int (__stdcall *fPTK_PrintPCX)(unsigned int px,unsigned int py,LPTSTR filename);
typedef int (__stdcall *fPTK_BinGraphicsList)();
typedef int (__stdcall *fPTK_BinGraphicsDel)(LPTSTR pid);
typedef int (__stdcall *fPTK_BinGraphicsDownload)(LPTSTR  name,unsigned int pbyte,unsigned int pH,UCHAR * Gdata);
typedef int (__stdcall *fPTK_RecallBinGraphics)(unsigned int  px, unsigned int  py, LPTSTR name);
typedef int (__stdcall *fPTK_DrawBinGraphics)(unsigned int px,unsigned int py,unsigned int pbyte,unsigned int pH,UCHAR * Gdata);
typedef int (__stdcall *fPTK_BmpGraphicsDownload)(LPTSTR  pcxname,LPTSTR pcxpath, int iDire);

typedef int (__stdcall *fPTK_DrawRectangle)(unsigned int px,unsigned int py,
							   unsigned int thickness,unsigned int pEx,
							   unsigned int pEy);
typedef int (__stdcall *fPTK_DrawLineXor)(unsigned int px,unsigned int py,
							 unsigned int pbyte,unsigned int pH);
typedef int (__stdcall *fPTK_DrawLineOr)(unsigned int px,unsigned int py,
							unsigned int plength,unsigned int pH);
typedef int (__stdcall *fPTK_DrawDiagonal)(unsigned int px,unsigned int py,
							  unsigned int thickness,unsigned int pEx,unsigned int pEy);
typedef int (__stdcall *fPTK_DrawWhiteLine)(unsigned int px,unsigned int py,
							   unsigned int plength,unsigned int pH);


typedef int (__stdcall *fPTK_RWRFIDLabel)(int nRWMode, int nWForm,
							 int nStartBlock, int nWDataNum,
							 int nWArea,LPTSTR pstr);

typedef int (__stdcall *fPTK_SetRFLabelPWAndLockRFLabel)(int nOperationMode, int OperationnArea,LPTSTR pstr);
typedef int (__stdcall *fPTK_SetRFIDLabelRetryCount)(int nRetryCount);
typedef int (__stdcall *fPTK_SetRFID)(int nReservationParameters, int nReadWriteLocation,
						 int ReadWriteArea, int nMaxErrNum, int nErrProcessingMethod);


typedef int (__stdcall *fPTK_FeedBack)();
typedef int (_stdcall *fOpenUSBPort)(unsigned int nUSBID);
typedef int (_stdcall *fCloseUSBPort)(void);
typedef int (__stdcall *fPTK_ErrorReportUSB)(int USBport);
//typedef int (__stdcall *fPTK_ErrorReport)(int wPort, int rPort, DWORD BaudRate, BOOL HandShake);
typedef int (__stdcall *fPTK_ErrorReport)(int wPort, int rPort, DWORD BaudRate, 
											BOOL HandShake, int TimeOut);


typedef LPTSTR (__stdcall *fPTK_GetUSBID)(unsigned int nUSBID);
typedef int (_stdcall *fPTK_SendFile)(LPTSTR FilePath);

typedef int (_stdcall *fPTK_SoftFontList)();
typedef int (_stdcall *fPTK_SoftFontDel)(TCHAR pid);

typedef int (_stdcall *fPTK_FormList)();
typedef int (_stdcall *fPTK_FormDel)(LPTSTR pid);
typedef int (_stdcall *fPTK_FormDownload)(LPTSTR pid);
typedef int (_stdcall *fPTK_DefineVariable)(unsigned int pid,unsigned int pmax,TCHAR porder,LPTSTR pmsg);
typedef int (_stdcall *fPTK_DefineCounter)(unsigned  int id,unsigned int maxNum,TCHAR ptext,LPTSTR pstr,LPTSTR pMsg);
typedef int (_stdcall *fPTK_FormEnd)();
typedef int (_stdcall *fPTK_ExecForm)(LPTSTR pid);
typedef int (_stdcall *fPTK_Download)();
typedef int (_stdcall *fPTK_DownloadInitVar)(LPTSTR pstr);

typedef int (_stdcall *fPTK_PrintLabelAuto)(unsigned int number,unsigned int cpnumber);
typedef int (_stdcall *fPTK_PrintConfiguration)();
typedef int (_stdcall *fPTK_DisableBackFeed)();
typedef int (_stdcall *fPTK_EnableBackFeed)(unsigned int distance);
typedef int (_stdcall *fPTK_EnableFLASH)();
typedef int (_stdcall *fPTK_DisableFLASH)();
typedef int (_stdcall *fPTK_Reset)();
typedef int (_stdcall *fPTK_FeedMedia)();
typedef int (_stdcall *fPTK_MediaDetect)();
typedef int (_stdcall *fPTK_CutPage)(unsigned int page);
typedef int (_stdcall *fPTK_CutPageEx)(unsigned int page);
typedef int (_stdcall *fPTK_MediaDetect)();
typedef int (_stdcall *fPTK_SetPrinterState)(TCHAR state);
typedef int (_stdcall *fPTK_SetCoordinateOrigin)(unsigned int px,unsigned int py);
typedef int (_stdcall *fPTK_SetFontGap)(int gap);
typedef int (_stdcall *fPTK_SetBarCodeFontName)(UCHAR Name,unsigned int FontW,unsigned int FontH);
typedef int (_stdcall *fPTK_SetCharSets)(unsigned int BitValue,UCHAR CharSets,LPTSTR CountryCode);
typedef int (_stdcall *fPTK_RenameDownloadFont)(unsigned int StoreType,UCHAR Fontname,LPTSTR DownloadFontName);





fOpenPort OpenPort = NULL;
fClosePort ClosePort = NULL;
fPTK_PrintLabel PTK_PrintLabel = NULL;
fPTK_ClearBuffer PTK_ClearBuffer = NULL;
fPTK_SetDirection PTK_SetDirection = NULL;

fPTK_DrawText PTK_DrawText =NULL;
fPTK_DrawBar2D_DATAMATRIX PTK_DrawBar2D_DATAMATRIX= NULL;
fPTK_DrawBar2D_QR PTK_DrawBar2D_QR = NULL;
fPTK_DrawBar2D_MaxiCode PTK_DrawBar2D_MaxiCode = NULL;
fPTK_DrawBar2D_Pdf417 PTK_DrawBar2D_Pdf417 = NULL;
fPTK_DrawBar2D_HANXIN PTK_DrawBar2D_HANXIN = NULL;
fPTK_DrawBarcode PTK_DrawBarcode = NULL;

fPTK_SetDarkness PTK_SetDarkness = NULL;
fPTK_SetPrintSpeed PTK_SetPrintSpeed = NULL;

fPTK_SetLabelHeight PTK_SetLabelHeight = NULL;
fPTK_SetLabelWidth PTK_SetLabelWidth = NULL;
fPTK_PcxGraphicsDel PTK_PcxGraphicsDel = NULL;
fPTK_PcxGraphicsList PTK_PcxGraphicsList = NULL;
fPTK_PcxGraphicsDownload PTK_PcxGraphicsDownload = NULL;
fPTK_DrawPcxGraphics PTK_DrawPcxGraphics = NULL;
fOpenUSBPort OpenUSBPort = NULL;
fCloseUSBPort CloseUSBPort = NULL;
//f = NULL;

fPTK_ErrorReportUSB  PTK_ErrorReportUSB = NULL;
fPTK_ErrorReport PTK_ErrorReport = NULL;
//fPTK_ErrorReportEx PTK_ErrorReportEx = NULL; 
fPTK_BmpGraphicsDownload PTK_BmpGraphicsDownload = NULL;
fPTK_DrawTextTrueTypeW PTK_DrawTextTrueTypeW = NULL;
fPTK_GetUSBID  PTK_GetUSBID = NULL;
fPTK_SendFile PTK_SendFile = NULL;

fPTK_GetInfo  PTK_GetInfo = NULL;
fSetPCComPort SetPCComPort = NULL;
fPTK_GetErrState PTK_GetErrState = NULL;
fPTK_DrawTextEx PTK_DrawTextEx = NULL;
fPTK_DrawBar2D_QREx PTK_DrawBar2D_QREx = NULL;
fPTK_DrawBarcodeEx PTK_DrawBarcodeEx = NULL;

fPTK_PrintPCX PTK_PrintPCX = NULL;
fPTK_BinGraphicsList PTK_BinGraphicsList = NULL;
fPTK_BinGraphicsDel PTK_BinGraphicsDel = NULL;
fPTK_BinGraphicsDownload PTK_BinGraphicsDownload = NULL;
fPTK_RecallBinGraphics PTK_RecallBinGraphics = NULL;
fPTK_DrawBinGraphics PTK_DrawBinGraphics = NULL;

fPTK_DrawRectangle PTK_DrawRectangle = NULL;
fPTK_DrawLineXor PTK_DrawLineXor = NULL;
fPTK_DrawLineOr PTK_DrawLineOr = NULL;
fPTK_DrawDiagonal PTK_DrawDiagonal = NULL;
fPTK_DrawWhiteLine PTK_DrawWhiteLine = NULL;

fPTK_RWRFIDLabel PTK_RWRFIDLabel = NULL;
fPTK_SetRFLabelPWAndLockRFLabel PTK_SetRFLabelPWAndLockRFLabel = NULL;
fPTK_SetRFIDLabelRetryCount PTK_SetRFIDLabelRetryCount = NULL;
fPTK_SetRFID PTK_SetRFID = NULL;

fPTK_FeedBack PTK_FeedBack = NULL;
fPTK_SoftFontList PTK_SoftFontList =NULL;
fPTK_SoftFontDel PTK_SoftFontDel =NULL;
fPTK_FormList PTK_FormList =NULL;
fPTK_FormDel PTK_FormDel =NULL;
fPTK_FormDownload PTK_FormDownload =NULL;
fPTK_DefineVariable PTK_DefineVariable =NULL;
fPTK_DefineCounter PTK_DefineCounter =NULL;
fPTK_FormEnd PTK_FormEnd =NULL;
fPTK_ExecForm PTK_ExecForm =NULL;
fPTK_Download PTK_Download =NULL;
fPTK_DownloadInitVar PTK_DownloadInitVar =NULL;
fPTK_PrintLabelAuto PTK_PrintLabelAuto =NULL;
fPTK_PrintConfiguration PTK_PrintConfiguration =NULL;
fPTK_DisableBackFeed PTK_DisableBackFeed =NULL;
fPTK_EnableBackFeed PTK_EnableBackFeed =NULL;
fPTK_EnableFLASH PTK_EnableFLASH =NULL;
fPTK_DisableFLASH PTK_DisableFLASH =NULL;
fPTK_Reset PTK_Reset =NULL;
fPTK_FeedMedia PTK_FeedMedia =NULL;
fPTK_MediaDetect PTK_MediaDetect =NULL;
fPTK_CutPage PTK_CutPage =NULL;
fPTK_CutPageEx PTK_CutPageEx =NULL;
fPTK_SetPrinterState PTK_SetPrinterState =NULL;
fPTK_SetCoordinateOrigin PTK_SetCoordinateOrigin =NULL;
fPTK_SetFontGap PTK_SetFontGap =NULL;
fPTK_SetBarCodeFontName PTK_SetBarCodeFontName =NULL;
fPTK_SetCharSets PTK_SetCharSets =NULL;
fPTK_RenameDownloadFont PTK_RenameDownloadFont =NULL;

//WINPSK DLL Function Declaration end
#endif