   M S B A M L   `   `   `  ����P  LDay06ScoopSelectorAli, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Day06ScoopSelectorAliDay06ScoopSelectorAli  5   	   &     Day06ScoopSelectorAli.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Day06ScoopSelectorAli     5   	     � 
ResizeMode$  NoResize=�5       � Title$ 
MainWindow��5   	   $	��320��6   $	��477��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $��8* �6   �� 5      $	��10* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��2* �6   .+�5   
   �� $��	Flavours:��6   $
��Left=�6$   $
��Left=�6F   $��10,0,0,0q�6a   $��Bottom=�6s   $	��148��6�   �� 5   
   -   5        $��
lvFlavours��5      $��	10,0,0,10q�6&   $��1��69   $��2��6F   .@�5      �� .��6   	Vanilla6$   �� 5      .��6   	Chocolate6&   �� 5      .��6   
Strawberry6'   �� 5      .��6   Kiwi6!   �� 5      .��6   
Rocky road6'   �� 5      .��6   Mango6"   5      �� 5   
   -   5        $��Add >>��5   -   $��1��6>   $��1��6N   $��Center=�6[   $��Center=�6x   $��75��6�   �� 5   
   $��	Selected:��6   $
��Left=�6$   $
��Left=�6F   $��10,0,0,0q�6a   $��Bottom=�6s   $	��148��6�   $��2��6�   �� 5    
   -   5        $��
lvSelected��5       $��0,0,10,0q�6%   $��1��67   $��2��6D   �� 5!   
   $��2��6   $��2��6%   .+�5"      �� -   5        $��Delete scoop(s)��5"   :   $��	0,12,10,0q�6T   �� 5#      -   5        $��
Delete all��5#   /   $��	0,10,10,0q�6D   5$      �� 5%   
   -   5        $��Place order��5%   ,   $��1��6B   $��Center=�6R   $��Center=�6o   $��2��6�   $��75��6�   5&      5'      