   M S B A M L   `   `   `  ����G  CFinalFlights, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalFlightsFinalFlights  5   	        FinalFlights.AddEditDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FinalFlights     5   	     � Title$  AddEditDialog��5   	   $	��300��6   $	��400��6,    � WindowStartupLocation$ CenterOwner=�68    � 
ResizeMode$ NoResize=�6\    � 	Resources 5	       �� 
TargetType �� Property �� Value��%R  '��       '�� �     �� 5
   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ Times New Roman)�6+   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ Times New Roman)�6+   �� 5       � ��$
 Bold"�6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��4* �6   6,   �� 5      $��6* �6   6,    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5       $��1* �6   6*   �� 5!      $��1* �6   6*   .+�5$   
   �� $
��Date��6   $
��Left=�6   $��14,10,0,9.6q�6:   $��Center=�6O   �� 5%   
   $��
From code:��6   $
��Left=�6%   $��13,12.4,0,10.2q�6@   $��1��6X   $��Center=�6e   $��23��6�   �� 5&   
   $��To code:��6   $
��Left=�6#   $��12,10.8,0,10q�6>   $��2��6T   $��Center=�6a   	 J� RenderTransformOrigin$	 0.308,0.602&�6|   �� 5'   
   $��Domestic/International��6   $
��Left=�61   $��10,10,0,10.8q�6L   $��3��6b   $��Center=�6o   $	��155��6�   �� 5(   
   $��
Passengers��6   $
��Left=�6%   $��10,11.2,0,9.6q�6@   $��4��6W   $��Center=�6d   $	��155��6   $��2��6�   �� 5*   
   -   5        $��tbToCode��5*      $��1��6"   $��Right=�62   $��23��6N   $�� ��6[   $��Center=�6c   $	��200��6~   
 �� 	MaxLength$	
 100��6�   $��2��6�   $��0,0,20,0q�6�   �� 5+   
   -   5        $��
tbFromCode��5+      $��1��6$   $��Right=�64   $��23��6P   $�� ��6]   $��Center=�6e   $	��200��6�   $	
 100��6�   $��0,12.4,20.6,10.2q�6�   $��1��6�   ]� 5,   
   $��Center=�6   $��4��60   $��1��6=   $��Right=�6M   $	��200��6i   $��0,0,20,0q�6u   .+�5-      �� $
��Left=�6�    �� TextAlignment$ Center=�6�   $��20��6�   ��6   ��  �� StringFormat$	 {0}�� �� ElementName$ slPassengers�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5.      -   5        $��slPassengers��5.       � Maximum$	 200Q�6)    � Minimum$ 1Q�67    � Value$ 1Q�6D    �� TickPlacement$ BottomRight=�6N    �� TickFrequency$ 1Q�6j    �� IsSnapToTickEnabled . $	��170��6�   $��Right=�6�   5/      (  "System.Windows.Controls.DatePicker  50   
   -   5        $��	dpDueDate��50      $��1��6&   $��Right=�66   $��0��6S   $��Center=�6`   $	��200��6{   $��0,0,20,0q�6�   �� 51   
   -   5        $��	comboType��51      $��1��6$   $��Right=�64   $��3��6Q   $��Center=�6^   $	��200��6y   $��0,0,20,0q�6�   52      �� 53   
    �� IsCancel . $��Cancel��6!   $��1��62   $��Right=�6B   $��0,0,20,0q�6`   $��5��6r   $��Center=�6   $	��100��6�   �� 54   
   -   5        $��btAction��54   (   $
��Save��68   $��1��6G   $��Right=�6W   $��	0,0,130,0q�6t   $��5��6�   $��Center=�6�   $	��100��6�   56      57      