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
    bool ReadDi(short mdl, short index); // [0, 15]
    short SetDo(short mdl, short index, bool value);

private:
    HMODULE hmodule;
};

#endif // IOEXTENSION_H

