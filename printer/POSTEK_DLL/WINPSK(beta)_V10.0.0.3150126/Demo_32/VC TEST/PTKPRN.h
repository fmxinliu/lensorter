//CDFPSK.DLL函数声明头文件
#ifndef _PCDFPSK_H
#define _PCDFPSK_H
//CDFPSK DLL Function Declaration start
typedef int (__stdcall *fOpenPort)(LPCTSTR printername);
typedef int (__stdcall *fPTK_SetDarkness)(unsigned  int id);
typedef int (__stdcall *fPTK_SetPrintSpeed)(unsigned int px);
typedef int (__stdcall *fClosePort)(void);
typedef int (__stdcall *fPTK_PrintLabel)(unsigned int number,
		                                 unsigned int cpnumber);
typedef int (__stdcall *fPTK_DrawBarcode)(unsigned  int px,
		                        unsigned int  py,
								unsigned int  pdirec,
								LPTSTR        pCode,
								unsigned int  pHorizontal,
								unsigned int  pVertical,
								unsigned int pbright,
								char ptext,
								LPTSTR pstr);
typedef int (__stdcall *fPTK_DrawTextTrueTypeW)
		                            (int x,int y,int FHeight,
									int FWidth,LPCTSTR FType,
                                    int Fspin,int FWeight,
									BOOL FItalic,BOOL FUnline,
                                    BOOL FStrikeOut,
									LPCTSTR id_name,
									LPCTSTR data);
typedef int (__stdcall *fPTK_SetLabelHeight)
		                (unsigned int lheight, unsigned int gapH,int gapOffset,BOOL bFlag);
typedef int (__stdcall *fPTK_SetLabelWidth)(unsigned int lwidth);
typedef int (__stdcall *fPTK_ClearBuffer)();
typedef int (__stdcall *fPTK_DrawRectangle)(unsigned int    px,  unsigned int    py,   
                                            unsigned int   thickness,  unsigned int   pEx, 
                                            unsigned int   pEy); 
typedef int (__stdcall *fPTK_PcxGraphicsDel) (LPTSTR pid);
typedef int (__stdcall *fPTK_PcxGraphicsDownload) (char*  pcxname, char* pcxpath);
typedef int (__stdcall *fPTK_DrawPcxGraphics)(unsigned int  px, unsigned int  py, LPTSTR  gname);
typedef int (__stdcall *fPTK_DrawBar2D_Pdf417)(unsigned int x, unsigned int  y,
								      unsigned int w, unsigned int v,
								      unsigned int s, unsigned int c,
									  unsigned int px, unsigned int  py,
									  unsigned int r, unsigned int l,
								      unsigned int t, unsigned int o,					   
								      LPTSTR pstr);
typedef int (__stdcall *fPTK_DrawBar2D_QR)( unsigned int x,
								   unsigned int y,
								   unsigned int w, 
								   unsigned int v,
								   unsigned int o, 
								   unsigned int r,
								   unsigned int m, 
								   unsigned int g,
								   unsigned int s,
								   LPTSTR pstr);
typedef int (_stdcall *fPTK_DrawLineOr)(unsigned int px,unsigned int py,unsigned int plength,unsigned int pH);
typedef int (_stdcall *fPTK_DrawText)(unsigned  int px,unsigned int  py,
							  unsigned int  pdirec,unsigned int pFont,
							  unsigned int  pHorizontal,
							  unsigned int  pVertical,
							  char ptext,LPTSTR pstr);

fOpenPort OpenPort = NULL;
fPTK_SetDarkness PTK_SetDarkness = NULL;
fPTK_DrawTextTrueTypeW PTK_DrawTextTrueTypeW = NULL;
fPTK_SetPrintSpeed PTK_SetPrintSpeed = NULL;
fClosePort ClosePort = NULL;
fPTK_PrintLabel PTK_PrintLabel = NULL;
fPTK_DrawBarcode PTK_DrawBarcode = NULL;
fPTK_SetLabelHeight PTK_SetLabelHeight = NULL;
fPTK_SetLabelWidth PTK_SetLabelWidth = NULL;
fPTK_ClearBuffer PTK_ClearBuffer = NULL;
fPTK_DrawRectangle PTK_DrawRectangle = NULL;
fPTK_PcxGraphicsDel PTK_PcxGraphicsDel = NULL;
fPTK_PcxGraphicsDownload PTK_PcxGraphicsDownload = NULL;
fPTK_DrawPcxGraphics PTK_DrawPcxGraphics = NULL;
fPTK_DrawBar2D_Pdf417 PTK_DrawBar2D_Pdf417 = NULL;
fPTK_DrawBar2D_QR PTK_DrawBar2D_QR = NULL;
fPTK_DrawLineOr PTK_DrawLineOr =NULL;
fPTK_DrawText PTK_DrawText =NULL;
//CDFPSK DLL Function Declaration end
#endif