   M S B A M L   `   `   `  ????J  FSeaView.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SeaView.DesktopSeaView.Desktop  5   	   !    SeaView.Desktop.CheckInForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SeaView.Desktop     5   	   $??20(?5      $??Segoe UI)?6(     ? Title$  CheckInForm??5   	   $	??450??6   $	??800??6*   .??5	      ? $??20q?6    ? RowDefinitions 5
   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??0??6.   .+?5      ?? $
??Bold"?6   $??5q?6*   Reservation:6C   ?? 5      -   5         ??Name$ firstNameText??5      $??5q?6/   ?? 5      -   5        $ lastNameText??5      $??5q?6.   5      ?? 5   
   $ 
Horizontal=?6   $??1??6.   .+?5      ?? $
??Bold"?6   $??5q?6*   Room:6<   ?? 5      -   5        $ 	titleText??5      $??5q?6+   5      ?? 5    
   $ 
Horizontal=?6   $??2??6.   .+?5!      ?? $
??Bold"?6   $??5q?6*   Room Number:6C   ?? 5"      -   5        $ roomNumberText??5"      $??5q?60   5#      ?? 5$   
   $ 
Horizontal=?6   $??3??6.   .+?5%      ?? $
??Bold"?6   $??5q?6*   Cost/night:6B   ?? 5&      -   5        $ totalCostText??5&      $??5q?6/   5'      ?? 5(   
   -   5         ??Name$ checkInUser??5)      $??10q?5(      $??20 10q?6   $??4??6-   .??5)   @   Confirm Check-In6R   5*      5+      