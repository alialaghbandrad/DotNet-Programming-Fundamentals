   M S B A M L   `   `   `  ����G  CFinalFlights, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalFlightsFinalFlights  5   	       FinalFlights.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FinalFlights     5   	   -   5          � Title$  
MainWindow��5   	   $	��400��6    � SizeToContent$ Width=�6*    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   'm�       �� 5
   
   " m�6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ Times New Roman)�6+   5      5      .��5      ]� .+�5   
   o� $	��Top=�6   
�������.@�5      m� -   5        $��miFile��5      $
��File��6'   .@�5      m� -   5        $��miSaveSelected��5   7   $��Save selected Flights...��6M   �� 5      m� 5      -   5        $��miExit��5   -   $
��Exit��6;   5      m� 5      -   5        $��miEdit��5      $
��Edit��6%   .@�5      m� -   5        $��miAdd��5   2   $��
Add Flight��6?   m� 5      -   5        $��miUpdate��5   5   $��Edit Flight��6E   5      5      �� 5   
   $��Bottom=�6   
�������.@�5      �� -   5        $��	lblStatus��5      $��Total Flights: 8��6%   
�������6@   5      �� 5    
   -	   5        $��	lvFlights��5    8    � ContextMenu 5!      �� 5"      .@�5#      m� -
   5        $��Edit Flight��5#   9   �� 5$      m� 5%      -   5        $��Delete Flight��5%   9   5&       �� View 5(      �� 5)      .P�5*      �� $
��Date��6%    �� Width$	 200��63   	 �� DisplayMemberBinding	 6?   �� *DateCurrentCulture+�� 5+      $��	From Code��6%   $	 100��68   	 6E   �� *
FromCode+�� 5,      $��To Code��6%   $	 100��66   	 6C   �� *ToCode+�� 5-      $
��Type��6%   $	 100��63   	 6@   �� *
TypeStatus+�� 5.      $��
Passengers��6%   $	 100��69   	 6F   �� *
Passengers+5/      51      52      53      