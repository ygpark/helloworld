#include <stdio.h>
#include <assert.h>
#include <QDebug>
#include <QRegExp>
#include <QString>
#include <QDateTime>
#include <QDate>

int main()
{
    QString pattern = "yyyy-MM-dd";
    QString rxStr[] = { "(yyyy)", "MM", "dd", "T", "HH","mm", "mm", "ss", "Z", "-", ":" };
    int     arrSize = sizeof(rxStr)/sizeof(rxStr[0]);
    bool    hit[arrSize];
    for(int i=0; i<arrSize; i++) {
        hit[i] = false;
    }

    qDebug() << "size = " << arrSize;
    QRegExp rx("yyyy");
    qDebug() << rx.exactMatch(pattern);

    return 0;

    for (int i = 0; i<arrSize; i++) {
        //QRegExp rx(rxStr[i]);
        //if (rx.exactMatch(pattern)) {
            //qDebug() << "hit: " << rxStr[i];
        //}
    }


    return 0;
}
