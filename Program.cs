// Chocolate Wrappers
// To find the number of chocolates one can buy with a given amount
// Numbers of wrappers remaining after exchanging wrappers with chocolate and money remaining
// Sample Input : 20 3 5      Sample Output : 7 2 2 

//Chocolate Wrappers
using static System.Console;

///<sample>Getting the Money, Price of Chocolate and Wrappers Exchange for chocolate from user</sample>
Write ("Enter Money : ");
int.TryParse (ReadLine (), out int money);
Write ("Enter Price of chocolate : ");
int.TryParse (ReadLine (), out int price);
Write ("Enter Number of Wrappers to be Exchanged for a chocolate :");
int.TryParse (ReadLine (), out int wrappers);
if (money > 0 && price > 0 && wrappers > 1) {
   var result = GetChocolate (money, price, wrappers);
   WriteLine ($"\nThe Number of chocolates is {result.Choc}\nThe Remaining Money is {result.RemMoney}\nThe Remaining wrappers is {result.RemWrappers}");
} else
   WriteLine ("Enter Valid Input");

///<summary>GetChocolate" : This methods returns the Number of chocolate purchased, Money remaining and Wrappers remaining</summary>
///<param name="money">Money with the customer</param>
///<param name="price">Price of the customer</param>
///<param name="wrappers">Number of wrappers remaining with the customer</param>
(int Choc, int RemMoney, int RemWrappers) GetChocolate (int money, int price, int wrappers) {
   if (money >= price) {
      int choc = (money / price);
      int remMoney = money % price;
      int remWrapper = choc;
      while (remWrapper >= wrappers) {
         choc += remWrapper / wrappers;
         remWrapper = remWrapper % wrappers + remWrapper / wrappers;
      }
      return (choc, remMoney, remWrapper);
   } else
      return (0, money, 0);
}