   M S B A M L   `   `   `  ����G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  5   	   ,    &HealthyTeeth.Views.AdministratorWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HealthyTeeth.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5
   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5       � Title$< 6Здоровые зубы | Администратор��5   	   $	��393��6/   $	��527��6<    � Icon$0 */HealthyTeeth;component/Resources/logo.ico��6H   .��5      � 
����ح�.+�5   
   #  MaterialDesignThemes.Wpf.Card  $��20q�6   .��5      � .+�5      �� -   5         ��Name$ ClientsControl��5      $-��'Управление клиентами��61   $
��Left=�6P   
�������$��	10,55,0,0q�6~   $	��Top=�6�   $	��213��6�   6�   �� 5      -   5        $ EmployeesControl��5      $3��-Управление сотрудниками��63   $��Right=�6U   
�������$��245,55,10,0q�6�   $	��Top=�6�   $	��224��6�   6�   �� 5      -   5        $ ConsumablesControl��5      $3��-Управление расходниками��65   $
��Left=�6W   
�������$��
10,145,0,0q�6�   $	��Top=�6�   $	��213��6�   6�   �� 5      -   5        $ OrderConsumables��5      $+��%Заказать расходники��63   $��Right=�6Q   
�������$��245,145,10,0q�6�   $	��Top=�6�   $	��224��6�   6�   �� 5      -   5        $
 Exit��5      $��
Выход��6'   $��Center=�67   
�������$��247,224,10,0q�6g   $	��Top=�6}   $	��224��6�   6�   �� 5      -   5        $ CreateRecord��5      $#��Записать заявку��6/   $
��Left=�6I   
�������$��
10,224,0,0q�6w   $	��Top=�6�   $	��213��6�   6�   5      5      5      5      