#include <stdio.h>
#include <assert.h>
#include <QDebug>
#include <QRegExp>
#include <QString>
#include <QDateTime>
#include <QDate>

int main()
{
    QRegExp rx("((.*\\+00:00)||(.*-00:00))");

    QString string_good1 = "2000-01-01T00:00:00+00:00";
    QString string_good2 = "2000-01-01T00:00:00-00:00";
    QString string_bad1  = "2000-01-01T00:00:00";
    QString string_bad2  = "2000-01-01T00:00:00+11:11:11";

    assert(string_good1.contains(rx) == true);
    assert(string_good2.contains(rx) == true);
    //assert(string_bad1.contains(rx) == false);   // 버그??
    //assert(string_bad2.contains(rx) == false);   // 버그??

    assert(rx.exactMatch(string_good1) == true);
    assert(rx.exactMatch(string_good2) == true);
    assert(rx.exactMatch(string_bad1) == false);
    assert(rx.exactMatch(string_bad2) == false);

    return 0;
}
