   M S B A M L   `   `   `  ����  HS%    HS.Views.Pages.ReservationsView   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      W SFontAwesome5.Net, Version=2.1.4.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/  5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   6+   �� 5      $	��100 �6   6-   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��68   $��10(�5      $
��Auto��6!   ��5      �� *Reservations+ �� SelectedItem 5   .   �� *SelectedReservation+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         
FontWeight$
 Bold"�6%   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Въезд��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *ArrivalDate+6h     5      $
 Bold"�6%   $ 
Выезд��67    6F   �� *DepartureDate+6j     5      $
 Bold"�6%   $ Клиент��67    6G   �� *Client.Document+  5      $
 Bold"�6%   $ Стоимость��67    6J   �� *Cost+  5      $
 Bold"�6%   $ Комната��67    6H   �� *Room.Number+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Активна��6)    6:   �� *Active+5      �� 5   
   $��1��6   $	��Top=�6%   .+�5      ��  �� CornerRadius$ 10��6   
���   �$��2q�6;   $��90��6O   $��5q�6Z   ._�5      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Документ��6   $��10(�6D   $��Center=�5      $��Center=�5      ��5   R   �� *
Document+5   9   5       �� 5!      $��
Найти��6   $
��0 20q�6[   $��80��5"      $��30��6    ��5!   %   �� *#!SearchReservationByClientDocument+5"       �� 5#      $��50��6   $��50��6!   $
��0 20q�6[   ��6,   �� *CalculateClientReservation+��5$      �� *SelectedReservation+.��5%        FontAwesome5.ImageAwesome  	   Icon$	 Solid_Calculator=�6"   
   
Foreground

 �����6:   5&      �� 5'      $��50��6   $��50��6!   $
��0 20q�6[   ��6,   �� *ActivateReservationCommand+��5(      �� *SelectedReservation+.��5)        $	 Solid_Check=�6"   

 �����65   5*      5+      5,      5-      