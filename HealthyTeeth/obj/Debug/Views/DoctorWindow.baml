   M S B A M L   `   `   `  ����G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  5   	   %    HealthyTeeth.Views.DoctorWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HealthyTeeth.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$; 5Здоровые зубы | Список заявок��5
   	   $	��620��6/   $
��1020��6<   $	��620��6I   $
��1020��6Y   
����ح� � Icon$0 */HealthyTeeth;component/Resources/logo.ico��6�   .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��121* �6   �� 5      $��50 �6   �� 5      $	��120 �6   .+�5   
   � .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ removeRecord��5      $!��Удалить запись��6/   
�������$
��Left=�6[   $��5q�6v   $	��200��6�   6�   �� 5      -   5        $ addVisit��5      $)��#Оформить посещение��6+   
�������$
��Left=�6[   $��5q�6v   $	��200��6�   6�   5      �� 5      -   5        $
 exit��5      $��
Выход��6#   
�������$��Right=�6F   $��5q�6b   $	��200��6m   6y   5      #  MaterialDesignThemes.Wpf.Card  5   
   $��5q�6   $��1��6)   $��1��6:   .��5      � .+�5      �� $��Center=�6   $��0,50,0,0q�6:   $��Center=�6s   $ Vertical=�6�   y�6L   �� *EmptyVisibility+.+�5      �� $1��+/HealthyTeeth;component/Resources/empty.png��6   $	��150��6Q   $	��110��6]   �� 5      $&�� Записи не найдены��6    $��20(�69   5      �� 5      -   5         ��Name$ recordsList��5      $��Stretch=�60   $��5q�6U   ��6`   �� *DisplayedRecords+ �� SelectedItem 6�   �� *SelectedRecord+ �� View 5       �� 5!      P�5"      �� 5#   "   -   5        fio��$��ФИО��5#   >   	 �� CellTemplate	 5$   &   �� 5%   *   
 �� DataType"
 ��67   .R�5&   .   �� ��68   �� *ClientFullName+5'   +   5)   #   �� 5*   "   -   5        
dateRecord��$��Дата записи��5*   E   	 5+   &   �� 5,   *   "
 ��67   .R�5-   .   �� ��68   �� *Date+5.   +   50   #   52      54      55      56      �� 57   
   -   5        $��PaginatorPanel��57   .   $ 
Horizontal=�6   $��Center=�6D   $��2��6b   $��1��6o   .+�58      �� -   5        $ ToFirst��58      $��«��6=   $��0,7.5,0,7.5q�6I   
�������$��35��6q   $��50��6}   $��30(�6�      buttonTemplate#��[  6�    � Cursor$
 Hand��6�   �� 59      -	   5        $ 	PagesList��59   �   $��5,7.5q�6   $��35��6&     	paginator#��[ 62   $��Disabled=�6b   $��Stretch=�6  $��Stretch=�6+   6�   �� *Paginator.SelectedPageNumber+��6G  �� *DisplayedPages+��5;      �� 5<      .R�5=      �� $��Center=�65   $��Center=�6R   $��Italic$�6m   $��20��6�   $��45��6�   $��18(�6�    �� TextAlignment$ Center=�6�   ��6$   �� 6�   5>      ��5@      �� 5A      .R�5B      � $��Stretch=�6$   $��Stretch=�6B   5C      5E      �� 5F      -
   5        $ ToLast��5F      $ Center=�6%   
�������$��»��6n   $��0q�6z   $��35��6�   $��50��6�   $��30(�6�   #��[  6�   5G        5H   
   $��5q�6   $��3��6)   .��5I      �  � ColumnDefinitions 5J      �� 5K      $
��140* �6'   �� 5L      $
��100* �6'   �� 5M      $
��120* �6'   .+�5O      �� $��
Поиск��6   $��5q�6)   $��16(�64   �� 5P      $��5q�6   $��16(�6b   $��Stretch=�6p   $��Center=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$C =Введите ФИО пациента для поиска...��6�   ��6%   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5Q      $��1��6   .+�5R      �� $&�� Сортировка по ФИО��6    $��16(�69   $��5q�6G   	� 5S      -   5         	�Name$ 	Ascending��5S   "   $!��По возрастанию��65   $��16(�6N    	� 	GroupName$ A��6�    d� 	IsChecked 6\   �� *IsAscending+6�   	� 5T      -   5        $ 
Descending��5T   "   $��По убыванию��66   $��16(�6L   $ A��6�    6Z   �� *IsDescending+6�   5U      �� 5V      $��2��6   $��5,5,5,5q�6-   .+�5W      �� $��Фильтр даты��6    $��16(�63   (  "System.Windows.Controls.DatePicker  5X      $��30��6D   $! Начало периода��6P   $��16(�6�   $��0,0,0,0q�6�   $��Center=�6�      SelectedDate 6!   �� *	StartDate+6�     5Y      $��30��6B   $ Конец периода��6N   $��16(�6}   $��Center=�6�    6!   �� *	EndDate+6�   5Z      5[      5\      5]      5^      