   M S B A M L   `   `   `  ����Q  MDay09TodoWithDialogAli, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Day09TodoWithDialogAliDay09TodoWithDialogAli  5   	   *    $Day09TodoWithDialogAli.AddEditDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Day09TodoWithDialogAli     5   	     � Title$  AddEditDialog��5   	   $	��350��6   $	��400��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��300 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��8* �6   .+�5   
   � $��1��6   $��1��6   $	��240��6,   $	��Top=�69    5      �� 5      $��4* �6#   �� 5      $��6* �6#    5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��3* �6    .+�5      �� $��Task description:��6   $��0��60   $��0��6@   $
��Left=�6M   $��Center=�6h   �� 5      $��Difficulty:��6   $��0��6*   $��1��6:   $
��Left=�6G   $��Center=�6b   �� 5      $��	Due date:��6   $��0��6(   $��2��68   $
��Left=�6E   $��Center=�6`   $��80��6{   �� 5       $��Status:��6   $��0��6&   $��3��66   $
��Left=�6C   $��Center=�6^   $��80��6y   �� 5!      -   5        $��tbTask��5!      $��1��6$   $��0��64   $
��Left=�6A   $��Center=�6\   $	��138��6w   $��0,3,0,3q�6�   (  "System.Windows.Controls.DatePicker  5"      -   5        $��dpDeparture��5"      $��1��6,   $��2��6<   $��0,3,30,3q�6I   �� 5#      -   5        $��comboStatus��5#      $��1��6*   $
��Left=�6:   $��3��6U   $��Center=�6b   $	��140��6}   .@�5%      �� .��6   	Pending6(   �� 5&      .��6   Done6%   �� 5'      .��6   	Delegated6*   5(      �� 5)      $��1��6   $��4��6)   .+�5*      �� -   5        $��Add Todo��5*   1   $
��Left=�6D   $��Center=�6_   $	��120��6z   $��0,15,0,5q�6�   5+      5,      �� 5-   
   $��Save Selected��6   $��1��6)   $��0��69   $
��Left=�6F   $��Center=�6a   $	��150��6|   $��20,0,0,0q�6�   �� 5.   
   -   5        $��tbDiff��5.       �� IsSnapToTickEnabled .  �� TickPlacement$ BottomRight=�6:    �� TickFrequency$	 0.5Q�6V    � Minimum$ 15Q�6j    � Maximum$ 35Q�6w    � Value$ 22Q�6�   $��1��6�   $
��Left=�6�   $��Center=�6�   $	��138��6�   $��122,40,0,222.8q�6�   �� 5/   
   $��0��6�   $��1��6�   $
��Left=�6�   $��	73,40,0,0q�6�   $	��Top=�6�   	 J� RenderTransformOrigin$	 0.263,0.038&�6�   $��44��6  $��27��6  ��6   �� 
 �� StringFormat$
 {0:0.0}�� �� ElementName$ tbDiff�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6  50      51      