   M S B A M L   `   `   `  ����O  KAppointmentScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppointmentScheduler.ViewAppointmentScheduler.View  5   	   K*clr-namespace:AppointmentScheduler.HelpersAppointmentScheduler.Helpers  5   	   *    $AppointmentScheduler.View.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppointmentScheduler.View     5   	   >helpers*clr-namespace:AppointmentScheduler.Helpers     5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$ Window1��5   	   $	��450��6   $	��800��6&    � DataContext 5
   	   ��  � 	Resources 5      :   4AppointmentScheduler.Helpers.DateTimeToTimeConverter   TimeConverter��%   &	          5   
   6*   5      .��5      � .+�5   
   &   System.Windows.Controls.Calendar  -   5        $��userCalendar��5      $
��Left=�6�   $��
50,180,0,0q�6�   $	��Top=�6�   $	��166��6�   $	��178��6�      SelectedDate 6'   �� *SelectedDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 6   �� 6�   &   System.Windows.Controls.DataGrid  5   
      
IsReadOnly$
 True��5         AutoGenerateColumns$ False��5      $��275,180,33,36q�5      ��5      �� *MainAppointmentsList+$ PropertyChanged=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Customer��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 20* 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Customer.customerName+6a     5      $

 Type��6%   $	 20* 6L    63   �� *type+6L     5      $
 
Start Time��6%   $	 20* 6}    69   �� *start+ �� 	Converter# [  6}     5      $
 End Time��6%   $	 20* 6y    67   �� *end+# [  6y     5      $
 
Consultant��6%   $	 20* 6T    69   �� *userId+6T   5      �� 5   
   $
��Left=�6   $��	50,16,0,0q�6,   $	��Top=�6?   $	��120��6W   $	��139��6d   ��6p   �� *OpenCustomersWindow+��5      � 5       .+�5!      �� $��Media/customers-icon.png��6   $��50��6>   $��0,0,0,0q�6I   �� 5"      $��
0,45,0,-50q�6   .��60   	Customers6;   5#      5%      �� 5&   
   $
��Left=�6<   $��
212,16,0,0q�6W   $	��Top=�6k   $	��120��6�   $	��139��6�   ��6   �� *OpenAppointmentsWindow+.��5'      � .+�5(      �� $��Media/calendar-icon.png��6   $��50��69   $��	0,-10,0,0q�6D   �� 5)      $��
0,40,0,-50q�6   .��6,   Appointments6:   5*      5+      �� 5,   
   $
��Left=�67   $��
382,16,0,0q�6R   $	��Top=�6f   $	��120��6~   $	��139��6�   ��6   �� *OpenReportsWindow+.��5-      � .+�5.      �� $$��/View/Media/checklist-icon.png��6   $��50��6@   $��	0,-10,0,0q�6K   �� 5/      $��
0,40,0,-50q�6   $��Reports��6,   50      51      53      54      