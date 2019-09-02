#ifndef IOEXTENSION_H
#define IOEXTENSION_H

#include <Windows.h>

class IOExtension
{
public:
    IOExtension(void);
    virtual ~IOExtension(void);

    short Open();
    short Close();
    short Reset();
    short Switch(short card);
    short ReadDi(short mdl,short index, unsigned short *pValue);
    short SetDo(short mdl, short index, unsigned short value);

private:
    HMODULE hmodule;
};

#endif // IOEXTENSION_H

