   M S B A M L   `   `   `  ���� G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  %    HealthyTeeth.Views.DoctorWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:HealthyTeeth.Views     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � WindowStartupLocation$  CenterScreen=� � Title$; 5Здоровые зубы | Список заявок��$	��620��$
��1020��$	��620��$
��1020��
����ح� � Icon$0 */HealthyTeeth;component/Resources/logo.ico��.���  � RowDefinitions �� $��45 ��� $
��121* ��� $��50 ��� $	��120 �.+�� .+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ removeRecord��$!��Удалить запись��
�������$
��Left=�$��5q�$	��200���� -   $ addVisit��$)��#Оформить посещение��
�������$
��Left=�$��5q�$	��200���� -   $
 exit��$��
Выход��
�������$��Right=�$��5q�$	��200��#  MaterialDesignThemes.Wpf.Card  $��5q�$��1��$��1��.��� .+��� $��Center=�$��0,50,0,0q�$��Center=�$ Vertical=�y��� *EmptyVisibility+.+��� $1��+/HealthyTeeth;component/Resources/empty.png��$	��150��$	��110���� $&�� Записи не найдены��$��20(��� -    ��Name$ recordsList��$��Stretch=�$��5q����� *DisplayedRecords+ �� SelectedItem �� *SelectedRecord+ �� View �� P��� -   fio��$��ФИО��	 �� CellTemplate	 �� 
 �� DataType"
 ��.R��� ���� *ClientFullName+�� -   
dateRecord��$��Дата записи��	 �� "
 ��.R��� ���� *Date+�� -   $��PaginatorPanel��$ 
Horizontal=�$��Center=�$��2��$��1��.+��� -   $ ToFirst��$��«��$��0,7.5,0,7.5q�
�������$��35��$��50��$��30(�   buttonTemplate#��[  �� -	   $ 	PagesList��$��5,7.5q�$��35��  	paginator#��[ $��Disabled=�$��Stretch=�$��Stretch=� �� *Paginator.SelectedPageNumber+���� *!Paginator.DisplayedPagesNumbers+���� .R��� $��Center=�$��Center=�$��Italic$�$��20��$��45��$��18(� �� TextAlignment$ Center=����� ���� .R�� $��Stretch=�$��Stretch=��� -
   $ ToLast��$ Center=�
�������$��»��$��0q�$��35��$��50��$��30(�#��[    $��5q�$��3��.���  � ColumnDefinitions �� $
��140* ��� $
��100* ��� $
��120* �.+��� $��
Поиск��$��5q�$��16(��� $��5q�$��16(�$��Stretch=�$��Center=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$C =Введите ФИО пациента для поиска...������ *Search+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��.+��� $&�� Сортировка по ФИО��$��16(�$��5q�	� -    	�Name$ 	Ascending��$!��По возрастанию��$��16(� 	� 	GroupName$ A�� d� 	IsChecked �� *IsAscending+	� -   $ 
Descending��$��По убыванию��$��16(�$ A�� �� *IsDescending+�� $��2��$��5,5,5,5q�.+��� $��Фильтр даты��$��16(�(  "System.Windows.Controls.DatePicker  $��30��$! Начало периода��$��16(�$��0,0,0,0q�$��Center=�   SelectedDate �� *	StartDate+  $��30��$ Конец периода��$��16(�$��Center=� �� *	EndDate+