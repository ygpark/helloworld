#include <stdio.h>
#include <QDebug>
#include <QDate>

int main()
{
    QDate d(2004, 2, 29);
    qDebug() << d.isValid();
    qDebug() << d.toString(Qt::ISODate);
    printf("hello World~\n");
    return 0;
}
