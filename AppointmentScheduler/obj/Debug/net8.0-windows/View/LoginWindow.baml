   M S B A M L   `   `   `  ����O  KAppointmentScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AppointmentSchedulerAppointmentScheduler  5   	   [2clr-namespace:AppointmentScheduler.View.Converters$AppointmentScheduler.View.Converters  5   	   +    %AppointmentScheduler.View.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:AppointmentScheduler     5   	   I
converters2clr-namespace:AppointmentScheduler.View.Converters     5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$ Login��5
   	   $	��300��6   $	��600��6$    � 	Resources 5      :   4AppointmentScheduler.View.Converters.RegionConverter   RegionConverter��%   &	          5   
   6%   5      .��5      � .+�5   
   �� $��Center=�6   $��0,68,0,0q�6/   $��20(�6�   $��Center=�6�   $	��Top=�6�   $	��152��6�   $��30��6�   ��6A   �� *InputUsername+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5   
   $��Center=�6   $��	0,142,0,0q�6/   $��20(�6�   $��Center=�6�   $	��Top=�6�   $	��152��6�   $��30��6�   ��6B   �� *InputPassword+$ PropertyChanged=�$ TwoWay=�6�   �� 5   
   -   5        $��
LoginLabel��5   #   $��Username��6   $��Center=�65   $��0,31,0,0q�6R   $	��Top=�6d   $��20(�6|   �� 5   
   -   5        $��PasswordLabel��5   #   $��Password��6   $��Center=�68   $��	0,103,0,0q�6U   $	��Top=�6h   $��20(�6�   �� 5   
   -   5        $��LoginButton��5      $��Login��6E   $��Center=�6U   $��	0,214,0,0q�6r   $	��Top=�6�   $��35��6�   $	��218��6�   ��6$   �� *Authenticate+6�   �� 5   
   $
��Left=�6[   $��	10,10,0,0q�6v   $	��Top=�6�   ��6   �� *
UserRegion+ �� 	Converter# [  6�   5      5      