   M S B A M L   `   `   `  ����O  KAppointmentScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppointmentScheduler.ViewAppointmentScheduler.View  5   	   4    .AppointmentScheduler.View.AddUpdateAppointment   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppointmentScheduler.View     5   	     � Title$  AddUpdateAppointment��5   	   $	��450��6&   $	��400��63   .��5	      � .+�5
   
   �� $��Customer��6   $
��Left=�6#   $��	35,44,0,0q�6>   $	��Top=�6Q   �� 5   
   $
��Left=�6   $��
101,44,0,0q�6.   $	��Top=�6B   $��Center=�6Z   $	��165��6|   $��25��6�    �� DisplayMemberPath$ customerName��5      ��5      �� *	Customers+ �� SelectedItem 5      �� *SelectedApptCustomer+�� 5   
   $��Title��6   $
��Left=�6    $��	63,74,0,0q�6;   $	��Top=�6N   �� 5   
   $
��Left=�6   $��
101,74,0,0q�6-    �� TextWrapping$
 Wrap=�6A   $	��Top=�6�   $��Center=�6�   $	��165��6�   $��25��6�   ��6U   �� *
InputTitle+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Description��6   $
��Left=�6&   $��
25,104,0,0q�6A   $	��Top=�6U   �� 5   
   $
��Left=�6   $��101,104,0,0q�6-   $
 Wrap=�6B   $	��Top=�6�   $��Center=�6�   $	��165��6�   $��53��6�   ��6V   �� *InputDescription+$ PropertyChanged=�6�   �� 5   
   $��Location��6   $
��Left=�6#   $��
41,162,0,0q�6>   $	��Top=�6R   �� 5   
   $
��Left=�6   $��101,162,0,0q�6-   $
 Wrap=�6B   $	��Top=�6�   $��Center=�6�   $	��165��6�   $��25��6�   ��6V   �� *InputLocation+$ PropertyChanged=�6�   �� 5   
   $��Contact��6   $
��Left=�6"   $��
44,192,0,0q�6=   $	��Top=�6Q   �� 5   
   $
��Left=�6   $��101,192,0,0q�6-   $
 Wrap=�6B   $	��Top=�6�   $��Center=�6�   $	��165��6�   $��25��6�   ��6V   �� *InputContact+$ PropertyChanged=�6�   �� 5   
   $
��Type��6   $
��Left=�6   $��
60,222,0,0q�6:   $	��Top=�6N   �� 5   
   $
��Left=�6   $��101,222,0,0q�6-   $
 Wrap=�6B   $	��Top=�6�   $��Center=�6�   $	��165��6�   $��25��6�   ��6V   �� *	InputType+$ PropertyChanged=�6�   �� 5   
   $	��URL��6   $
��Left=�6   $��
65,252,0,0q�69   $	��Top=�6M   �� 5   
   $
��Left=�6   $��101,252,0,0q�6-   $
 Wrap=�6B   $	��Top=�6�   $��Center=�6�   $	��165��6�   $��25��6�   ��6V   �� *
InputURL+$ PropertyChanged=�6�   �� 5   
   $��Start��6   $
��Left=�6    $��
62,283,0,0q�6;   $	��Top=�6O   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6=   $��101,283,0,0q�6X   $	��Top=�6m   $	��165��6�      SelectedDate 6   �� *InputStartDate+6�   �� 5   
   -   5         � ToolTip$ Please use format 00:00��5   R   $
��Left=�6t   $��281,283,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $��Center=�6�   $��86��6�   $��24��6�   ��6   �� *InputStartTime+6�   �� 5   
   $	��End��6   $
��Left=�6   $��
66,311,0,0q�69   $	��Top=�6M   �� 5    
   -   5        $ Please use format 00:00��5    P   $
��Left=�6r   $��281,312,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $��Center=�6�   $��86��6�   $��24��6�   ��6   �� *InputEndTime+6�   �� 5!   
   -   5        $��btAction��5!   ;   $��Add Appointment��6K   $
��Left=�6e   $��
38,376,0,0q�6�   $	��Top=�6�   $��33��6�   $	��130��6�   ��6   �� *AddAppointmentConfirm+6�   5#      5$      