   M S B A M L   `   `   `  ����  HS6    0HS.Views.Windows.Creation.NewReservationByClient   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Create a reservation��5
   	   $	��550��6&   $	��400��63    � WindowStartupLocation$ CenterScreen=�6?    � DataContext 5	   	   �� *NewReservByClientViewModel+   Locator �� Source# [   J� InputBindings 5      �� 5   
    �� 	Modifiers$ Controlf�6   
 �� Key$ Q��6)     CloseAppCommand �� Command# [ 5      .��5      �� $��20q�6   .+�5      �� $	��Top=�6   .+�5      �� $��30(�6   $��Rieverra��6&   68   �� 5      
�������$��15(�6.   $K��EИтак, вы хотите забронировать комнату��6<   6k   �� 5      	 �� Orientation$	 
Horizontal=�6   $��0 20 0 0q�62   .+�5      �� $��15(�6   $��Комната: ��6*   6=   �� 5      $��15(�6   ��6*   �� *SelectedRoom.Number+6Q   5      �� 5      $	 
Horizontal=�6   $��0 20 0 0q�62   .+�5      �� $��15(�6   $��На ��6*   67   �� 5      $��15(�6   ��6*   �� * SelectedRoom.RoomType.Capacity+6\   �� 5      $��15(�6   $�� гостя/-ей��6*   6>   5      �� 5      $	 Vertical=�6   $��0 20 0 0q�60   .+�5      �� $��15(�6   $	��С ��6*   66   �� 5      $��15(�6   ��6*   �� *ArrivalDate+6I   �� 5       $��15(�6   $��По ��6*   67   �� 5!      $��15(�6   ��6*   �� *DepartureDate+6K   5"      �� 5$      $	 
Horizontal=�6   $��0 20 0 0q�62   .+�5%      �� $��15(�6   $��На имя: ��6*   6<   �� 5&      $��15(�6   ��6*   �� *CurrentClient.Surname+6S   �� 5'      $��15(�6   $��10 0 0 0q�5(      ��5'   *   �� *CurrentClient.Name+5(   0   5)      �� 5+      $	 
Horizontal=�6   $��0 20 0 0q�62   .+�5,      �� $��15(�6   $&�� Связаться с Вами: ��6*   6F   �� 5-      $��15(�6   ��6*   �� *CurrentClient.PhoneNumber+6W   5.      5/      �� 51   
   $	 
Horizontal=�6   $��Center=�6.   $��Center=�6K   $��	0 10 0 10q�52      $��Bottom=�6(   .+�53      �� $��20(�6   $��Итого: ��6&   67   �� 54      $��20(�6   ��6&   �� *Cost+6>   �� 55      $��20(�6   $�� рублей/-я��6&   6:   56      �� 58   
   $��Center=�6-   $��15(�6J   $
��0 10q�59      $
��Wrap=�6"   ��58      �� *	Message+��5:      �� *MessageColor+6:   �� 5<   
   $	 
Horizontal=�6   $��Bottom=�6.   $��Center=�6F   .+�5=      �� $��10 20q�6   $	��180��5>      $��15(�5?      $��Оформить��6#   $��40��66   
���������5>   !   �� *CreateNewReservCommand+5?   B   �� 5@      $	��180��6   $
��10 0q�6!   $��15(�5A      $��Отмена��6#   $��40��64   
�������6@   5B      5C      5D      