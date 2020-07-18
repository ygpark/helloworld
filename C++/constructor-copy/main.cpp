#include <iostream>
#include <stdio.h>
#include <sstream>
#include <assert.h>

using namespace std;

//----------------------------------------------------------------------------------------
class Item
{
    public:
        /**
         * @brief 생성자
         */
        Item() {
            this->val = 0;
        }

        /**
         * @brief 생성자
         *
         * @param val 멤버변수
         */
        Item(int val) {
            this->val = val;
        }

        /**
         * @brief 복사 생성자
         *
         * @note    복사생상자는 this와 &r의 주소가 같을 수 없으므로
         *          할당자(operator=)처럼 비교해서 리턴하지 않는다.
         *
         * @param r this로 복사할 대상
         */
        Item(const Item& r) {
            this->val = r.val;
        }

        /**
         * @brief 할당자
         *
         * @param r     this로 복사할 대상
         *
         * @note        할당자(operator=)는 this와 &r의 주소가 같으면
         *              복사할 필요가 없으므로 즉시 리턴한다.
         *
         * @return      this의 참조
         */
        Item& operator = (const Item& r) {
            if( this == &r) {
                return *this;
            }

            this->val = r.val;
            return *this;
        }

        /**
         * @brief 소멸자
         */
        ~Item() {
        }

    public:
        int val;
};

//----------------------------------------------------------------------------------------
/*
 * NOTE
 * ----
 *  생성자에 explicit이 없으면 ClassA c = Class(a); 처럼 변경되서 컴파일됨
 *
 *  예)
 *      //복사생성자를 호출하려 했으나 explicit때문에 실패
 *      ClassA error = a;     // Compile ERROR
 */
class ClassA
{
    public:
        /**
         * @brief 생성자
         */
        explicit ClassA() {
            this->init();
            this->item = new Item();
        }


        /**
         * @brief 생성자
         *
         * @param item 멤버변수
         */
        explicit ClassA(Item *item) {
            this->init();
            this->item = item;
        }

        /**
         * @brief 복사 생성자
         *
         * @note    복사생상자는 this와 &r의 주소가 같을 수 없으므로
         *          할당자(operator=)처럼 비교해서 리턴하지 않는다.
         *
         * @param r this로 복사할 대상
         */
        explicit ClassA(const ClassA &r) {
            this->init();
            this->item = new Item();

            if (this->item != NULL && r.item != NULL) {
                *(this->item) = *(r.item);
            }
        }

        /**
         * @brief 소멸자
         */
        ~ClassA() {
            delete item;
            item = NULL;
        }

        /**
         * @brief 할당자
         *
         * @param r     this로 복사할 대상
         *
         * @note        할당자(operator=)는 this와 &r의 주소가 같으면
         *              복사할 필요가 없으므로 즉시 리턴한다.
         *
         * @return      this의 참조
         *
         */
        ClassA& operator =(const ClassA &r) {
            if( this == &r) {
                return *this;
            }

            if (this->item != NULL && r.item != NULL) {
                *(this->item) = *(r.item);
            }

            return *this;
        }

    private:
        /**
         * @brief 초기화 함수
         */
        void init() {
            this->item = NULL;
        }

    public:
        Item *item;

};

//----------------------------------------------------------------------------------------

int main(void)
{
    ClassA a(new Item(5));  // 생성자 호출

    ClassA b(a);    // 복사생성자 호출
    assert(b.item->val == 5);

    ClassA c;
    c = a;  // operator= 호출
    assert(c.item->val == 5);

    ClassA d;
    d = d;  // operator= 호출
    assert(d.item->val == 0);

    ClassA e1, e2;
    e1.item = NULL;
    e1 = e2;

    ClassA f1, f2;
    f2.item = NULL;
    f1 = f2;

    return 0;
}

