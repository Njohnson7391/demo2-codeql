/*Filename: Program.cs
Project:A01 – C# AND OBJECT-ORIENTED PROGRAMMING
By: Neethu Johnson-8847391
Date: 17 September 2023
Description: A program to review some OOP basics
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A01
{

    //class name Program that implements the main function
    internal class Program

    {
        static void Main(string[] args)
        {

            //Instantiate each of the three subclasses
            SavingsAccount savingsaccount = new SavingsAccount(84560, 3000, 2.5);
            ChequingAccount chequingAccount = new ChequingAccount(56489, 5000, 2.4);
            LoanAccount loanAccount = new LoanAccount(20783, -5888, 5.5);

             
            //Demonstrating accessing inherited properties
            Console.WriteLine("Savings Account Information:");
            savingsaccount.DepositTrans(400);
            savingsaccount.WithdrawTrans(200);
            savingsaccount.GetAccntInfo();
            Console.WriteLine("\n");
            Console.WriteLine("****************************************");
            

            Console.WriteLine("Chequing Account Information:");
            chequingAccount.DepositTrans(1000);
            chequingAccount.WithdrawTrans(50);
            chequingAccount.GetAccntInfo();
            Console.WriteLine("\n");
            Console.WriteLine("****************************************");
          

            Console.WriteLine("Loan Account Information:");
            loanAccount.DepositTrans(500);
            loanAccount.GetAccntInfo();
            Console.WriteLine("\n");
            Console.WriteLine("****************************************");
         
            //Demonstrating accessing unique properties and methods
            savingsaccount.ApplyInterest();
            Console.WriteLine("\nSavings Account Interest rate is {0}%", savingsaccount.IntrRate);
            chequingAccount.ApplyAnnualFee();
            Console.WriteLine("\nChequing Account Annual Fee is ${0}", chequingAccount.AnnualFee);
            loanAccount.CalInterest();
            Console.WriteLine("\nLoan Account Interest is {0}%", loanAccount.LoanIntrRate);

            Console.WriteLine("\nAfter the transactions:");
            savingsaccount.GetAccntInfo();
            chequingAccount.GetAccntInfo();
            loanAccount.GetAccntInfo();
            Console.ReadLine();
        }
    }


    public class Account
    {
        //variables declarations
        public int AccntNum { get; set; }
        public double CurrBalance { get; set; }

        //deafult constructor (empty one)
        public Account()
        {

        }
         
        /*overloaded constructor with two parameters: int accntNum and 
        double currBalance*/
        public Account(int accntNum, double currBalance)
        {
            AccntNum = accntNum;
            CurrBalance = currBalance;
        }

        //deposit transaction method
        public void DepositTrans(double Rate)
        {
            CurrBalance += Rate;
            Console.WriteLine("Deposited amount is ${0}. The current balance is ${1} .",Rate, CurrBalance);

        }

        //withdraw transaction method
        public void WithdrawTrans(double Rate)
        {
            if (Rate >= CurrBalance)
            {
                CurrBalance -= Rate;
                Console.WriteLine("Withdrew amount is ${0} . Now the current balance is ${1}", Rate, CurrBalance);
            }
            else
            {
               
                Console.WriteLine("Insufficient Balance. Check your account details");
            }
        }

        //method to get account information
        public virtual void GetAccntInfo()
        {
            Console.WriteLine("Account Number: {0} , Current Balance: {1}", AccntNum, CurrBalance);
        }

    }


    //SavingsAccount class that inherited from Account class
    public class SavingsAccount : Account
    {
        //variable declarations
       public double IntrRate { get; set; }
      

        //default constructor (empty one)
       public SavingsAccount()
        {

        }

        //overloaded constructor of SavingsAccnt()
        public  SavingsAccount(int AccontNum, double InitBalance,double InterRate)
        
        {
            AccntNum = AccontNum;
            IntrRate = InterRate;
           
        }

        //applying interest method
        public void ApplyInterest()
        {
            double interAmount = CurrBalance * (IntrRate / 100);
            DepositTrans(interAmount);
            Console.WriteLine("Interest has been applied. Rate is {0}%", interAmount); 
            
         }

        //override get Information method in Account Class since added virtual in Account class
        public override void GetAccntInfo()
        {
            base.GetAccntInfo();
            Console.WriteLine("************************************");
            Console.WriteLine("\nSavings Account: {0}\nInterest Rate : {1}%,\nAvailable balance: ${2}", AccntNum, IntrRate, CurrBalance);
        }


    }


    //ChequingAccount class that is inherited from Account class
    public class ChequingAccount : Account
    {
        public double AnnualFee { get; set; }
        
        //default constructor
        public ChequingAccount() 
        {
        }

        //overloading ChequingAccount()
        public ChequingAccount(int AccountNum, double initBalanace, double TotalAmont)
        {
            AccntNum=AccountNum;
            AnnualFee = TotalAmont;
        }

        //Applying annual fee method
        public void ApplyAnnualFee()
        {
            CurrBalance -= AnnualFee;
            Console.WriteLine("Annual fee has been applied. Now your current balance is ${0}", CurrBalance);
        }

        //Overriding get account information method
        public override void GetAccntInfo()
        {
            base.GetAccntInfo();
            Console.WriteLine("*********************************");
            Console.WriteLine("\nChequing Account:{0}, \nBalance available: ${1}, \nAnnual Fee : ${2}", AccntNum, CurrBalance, AnnualFee);
        }

    }


    //LoanAccount class that is inherited from Account class
    public class LoanAccount : Account
    {
        //variable declaration
        public double LoanIntrRate { get; set; }

        //default constructor
        public LoanAccount()
        {
        }

        //overloaded construcctor of LoanAccount()
        public LoanAccount(int AccountNum, double initlBalance, double LoanInterest)
        {
            AccntNum= AccountNum;   
            LoanIntrRate = LoanInterest;
        }



        //Method to calculate interest rate
        public void CalInterest()
        {
            double interestrate = CurrBalance * (LoanIntrRate / 100);
            CurrBalance += interestrate;
            Console.WriteLine("Interest has been applied. Amount is {0}", interestrate);

        }

    
        //Override method of get account information
        public override void GetAccntInfo()
        {
            base.GetAccntInfo();
            Console.WriteLine("**************************************");
            Console.WriteLine("\nLoan Account: {0}, \nBalance: ${1}, \nLoan Interest Rate: {2}%", AccntNum, CurrBalance,LoanIntrRate);
        
        }

        }
    }




