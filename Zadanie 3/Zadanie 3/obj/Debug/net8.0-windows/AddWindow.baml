   M S B A M L   `   `   `  ����D  @Zadanie 3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Zadanie_3	Zadanie_3  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Zadanie_3.AddWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Zadanie_3     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  Add Book��5	   	   $	��400��6   $	��300��6'    � 	Resources 5         genreValues S� 
MethodName S� 
ObjectTypeU QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Enum S� MethodParameters M� TypeName��%v   &	        S� 5   
   $ 	GetValues��61   "  6H    5      M� 5      $ local:BookGenre��6   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5"   
   �� $��Title:��6   $��0��6!   $��0��6.   $��5q�6>   �� 5#   
   -   5         ��Name$ TitleTextBox��5#      $��0��6(   $��1��65   $��5q�6E   ��6P   �� *Title+�� 5%   
   $��Author:��6   $��1��6"   $��0��6/   $��5q�6?   �� 5&   
   -   5        $ AuthorTextBox��5&      $��1��6)   $��1��66   $��5q�6F   ��6Q   �� *Author+�� 5(   
   $��
Publisher:��6   $��2��6%   $��0��62   $��5q�6B   �� 5)   
   -   5        $ PublisherTextBox��5)      $��2��6,   $��1��69   $��5q�6I   ��6T   �� *	Publisher+�� 5+   
   $��Genre:��6   $��3��6!   $��0��6.   $��5q�6>   �� 5,   
   -   5        	 ��Name$	 GenreComboBox��5,      $��3��6*   $��1��67   $��5q�6G   ��6R   �� 
 �� Source#
 [   �� SelectedItem 6�   �� *Genre+�� 5.   
   $��Page Count:��6   $��4��6&   $��0��63   $��5q�6C   �� 5/   
   -   5        $ PageCountTextBox��5/      $��4��6,   $��1��69   $��5q�6I   ��6T   �� *	PageCount+�� 51   
   $��Publication Date:��6   $��5��6,   $��0��69   $��5q�6I   (  "System.Windows.Controls.DatePicker  52   
   -   5          Name$ PublicationDatePicker��52      $��5��64   $��1��6A   $��5q�6Q      SelectedDate 6\   �� *PublicationDate+�� 54   
   $��6��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�6F   $��Right=�6_   $��5q�6{   .+�55      �� -   5         ��Name$ 	AddButton��55      $	��Add��6(   $��60��6N   $��0,0,5,0q�6Y   �� 56      -   5        $ CancelButton��56      $��Cancel��6+   $��60��6W   57      58      59      