   M S B A M L   `   `   `  ����F  BBus_Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Bus_StationBus_Station  5   	       Bus_Station.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Bus_Station     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
     � Title$  Автовокзал��5	   	   $	��450��6   $	��800��6)   $	��350��66   $	��700��6F    � 	Resources 5       �� 
TargetType �� Property �� Value��%|  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ Times New Roman)�63   �� 5       � ��$ 24(�61   �� 5       � ��$
 Bold"�63   5      �� 5   
   " ��6   .�5      ��  � �� �#84848463   �� 5       � ��$ Times New Roman)�63   �� 5       � ��$ 18(�61   �� 5       � ��$
 Bold"�63   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      �� 5       � ColumnDefinitions 5!   
   �� 5"      $
��0.3* �6   �� 5#      $
��0.4* �6   �� 5$      $
��0.3* �6   .+�5'   
   �� $��1��6   $��0��6    $&�� Добро пожаловать!��6-   $��Center=�6I   $��Center=�6f   $	��230��6�   $��35��6�   �� 5)   
   $��0��6   $��1��6    $��Bus5.png��6-   �� 5*   
   $��1��6   $��1��6%   $��Center=�62   $��Center=�6O   .+�5+      �� $��1��6   $��1��6$   $/��)Выберите пользователя��61   $��Stretch=�6Q   $	��Top=�6o   $	��300��6�   $��35��6�   $��0,0,0,10q�6�   �� 5,      $��Кассир��67   $	��200��6I      MaterialDesignFlatButton#���   6X   $��Times New Roman)�6�   $
��Bold"�6�   $��2q�6�   
��� ���$��0 0 0 10q�6�   ��6   �� *CashierButton+6�   �� 5-      $ ��Администратор��6=   $	��200��6V   #���   6e   $��Times New Roman)�6�   $
��Bold"�6�   $��2q�6�   
��� �����6   �� *AdministratorButton+6�   5.      5/      50      