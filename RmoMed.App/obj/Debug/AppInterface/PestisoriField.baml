   M S B A M L   `   `   `  ����E  ARmoMed.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:RmoMed.App.AppInterfaceRmoMed.App.AppInterface  5   	   ,    &RmoMed.App.AppInterface.PestisoriField   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:RmoMed.App.AppInterface     5   	   -   5          � Title$  	Pestisori��5   	   $	��600��6   $	��600��6(    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�5   	   ��6!   Z� .��5      � .+�5   
   � -   5         �Name$ leftSide��5      $
��Left=�6!   .+�5      � $	��150��6   $
��Left=�6   $	��Top=�6:    � RowDefinitions 5      �� 5      $��2* �6$   �� 5      $��* �6$   �� 5      $	��100 �6$   .+�5      �� -   5         ��Name$ label��5   %   $��0��6   $��Timer��64   $��Center=�6D   $	��Top=�6a   
�������$��20(�6�   � 5      $��1��6   $	��400��6$   .+�5      �� -   5        $ TimerCountDown��5      $
��80px(�64   $��Center=�6D   $	��Top=�6a   
�������.��6�   006�   5      � 5      $��2��6   .+�5      �� -   5        $ lablse��5      $��Scorul��6,   $��Center=�6=   $��0q�6Z   $	��Top=�6e    J� RenderTransformOrigin$ 0.503,-0.59&�6}   $��20(�6�   ���	#FFF7F5F56�   �� 5      -   5        $ lbScore��5      $��00��6-   $��Center=�6:   $��0q�6W   $��Bottom=�6b   $ 0.503,-0.59&�6}   $��60(�6�   ���	#FF00FF3A��6�   Z� 5      5!      5"      � 5#   
   -   5        $ 	GameField��5#      $��Center=�6"   $��Center=�6?   .+�5$      �� -   5        	 ��Name$	 
background��5$      ��5%      �� 5&      
 �� DecodePixelWidth$

 1500��6"    �� 	UriSource$! /Image/pestisori-fundal.png?�6:   5(      � 5)      -	   5        $ 
GmInteract��5)      5+      5-      � 5.   
   -
   5        $ 	rightSide��5.      $��Right=�6"   $��0,0,10,0q�6>   .+�5/      � $	��150��6   $��Right=�6   $	��Top=�6;    50      �� 51      $��2* �6$   �� 52      $��* �6$   �� 53      $	��100 �6$   .+�55      �� -   5        $ label1��55   %   $��0��6   $��Caută peștișorul:��65   $��Center=�6Q   $	��Top=�6n   
�������$��20(�6�   $��0q�6�   � 56      $��1��6   $	��400��6$   .+�57      �� -   5        $	 findPestisor��57      $��Center=�62   $	��Top=�6O   58      � 59      $��2��6   5;      5<      5=      5>      5?      