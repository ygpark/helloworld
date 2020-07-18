#include <stdio.h>
#include <QDebug>
#include <QDateTime>

int main()
{
    QDateTime dt(QDate(2004, 2, 29), QTime(1,0,0));
    qDebug() << dt.toString("yyyy");
    qDebug() << dt.toString(Qt::ISODate);

    qDebug() << "--------------------";
    QDateTime local(QDateTime::currentDateTime());
    QDateTime UTC(local.toTimeSpec(Qt::UTC));
    QDateTime UTC2(UTC.toTimeSpec(Qt::UTC));
    qDebug() << "Local time is:" << local.toString();
    qDebug() << "UTC time is:" << UTC.toString();
    qDebug() << "UTC2 time is:" << UTC2.toString();
    qDebug() << "No difference between times:" << local.secsTo(UTC);
    return 0;
}
