   M S B A M L   `   `   `  ����P  LDay05MultiTempConvAli, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Day05MultiTempConvAliDay05MultiTempConvAli  5   	   &     Day05MultiTempConvAli.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Day05MultiTempConvAli     5   	     � Title$  
MainWindow��5   	   $	��200��6   $	��313��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��14* �6   �� 5      $	��10* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6    �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Input��6   $��1��6$   $
��Left=�64   $��40��6O   $	��Top=�6Z   �� 5      -   5        $��tbInput��5      $
��Left=�6t   $��23��6�   $��5,4,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��10��6�   $	��Top=�6�   $��60��6�   5      �� 5   
   $��1��6   $��3��6%   $ 
Horizontal=�62   .+�5      �� $��Output��6   $��1��6%   $
��Left=�65   $��50��6P   $	��Top=�6[   �� 5      -   5        $��tbOutput��5      $
��Left=�6&   $��23��6A   $��5,4,0,0q�6M   $
 Wrap=�6^   $��10��6r   $	��Top=�6|   $��60��6�   5      �� 5   
   $��1��6   $��8,0,0,0q�6"    � 	Resources 5       �� 
TargetType �� Property �� Value��%W   '	�       �� 5      " 	�6   .�5      ��  � ��$ 0,5,0,0q�6/   5       5!      .+�5"      �� $��Input Scale��6   	� 5#      -   5        $��rbInCel��5#      $��Celsius��6F   	 d� 	IsChecked$
	 TrueY�6X   	� 5$      -   5        $��rbInFah��5$      $��
Fahrenheit��6F   	� 5%      -   5        $��rbInKel��5%      $��Kelvin��6F   5&      �� 5'   
   $��1��6   $��2��6"   $��8,0,0,0q�62    5(      ��%W   '	�       �� 5)      " 	�6   .�5*      ��  � ��$ 0,5,0,0q�6/   5+      5,      .+�5-      �� $��Output Scale��6   	� 5.      -   5        $��rbOutCel��5.      $��Celsius��6G   $
	 TrueY�6Y   	� 5/      -   5        $��rbOutFah��5/      $��
Fahrenheit��6G   	� 50      -   5        $��rbOutKel��50      $��Kelvin��6G   51      52      53      