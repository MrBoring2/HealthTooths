   M S B A M L   `   `   `  ���� G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  ,    &HealthyTeeth.Views.EmployeesListWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:HealthyTeeth.Views     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml    � Title$E  ?Здоровые зубы | Список сотрудников��$	��750��$
��1126��$	��750��$	��970�� � Icon$0 */HealthyTeeth;component/Resources/logo.ico��.��� 
����ح� � RowDefinitions �� $
��200* ��� $��50 ��� $	��150 ��� $��50 �.+�#  MaterialDesignThemes.Wpf.Card  $��20q�$��1��.��� .+��� $��Center=�$��Center=�y��� *EmptyVisibility+.+��� $1��+/HealthyTeeth;component/Resources/empty.png��$	��200��$��Center=��� $3��-Поиск не дал результатов��$��20(�$��Center=��� -    ��Name$ EmployeesList������ *DisplayedEmployees+ �� SelectedItem �� *SelectedEmployee+ �� View �� P��� -   fio��$��ФИО�� �� CellTemplate ��  �� DataType" ��.R��� ���� *
FullName+�� -   
gender��$��Пол�� �� " ��.R��� ���� *Gender+�� -   role��$��Роль�� �� " ��.R��� ���� *Role.RoleName+�� -   passport��$'��!Паспортные данные�� �� " ��.R��� ���� *
Passport+�� -   phoneNumber��$!��Номер телефона�� �� " ��.R��� ���� *PhoneNumberText+�� -   $��PaginatorPanel�� �� Orientation$ 
Horizontal=�$��Center=�$��1��$��1��.+��� -   	 ��Name$	 ToFirst��$��«��$��0,7.5,0,7.5q�
�������$��35��$��50��$��30(�   buttonTemplate#��[  �� -	   $ 	PagesList��$��5,7.5q�$��Disabled=�  	paginator#��[ $��Stretch=�$
��Auto��$��Stretch=�$��Stretch=� �� *Paginator.SelectedPageNumber+���� *!Paginator.DisplayedPagesNumbers+���� .R��� $��Center=�$��Center=�$��Italic$�$��20��$��45��$��18(�
 �� TextAlignment$
 Center=����� ���� .R�� �� -
   $	 ToLast��$
 Center=�
�������$��»��$��0q�$��35��$��50��$��30(�#��[    $��2��$��	20,5,20,5q�.���  � ColumnDefinitions �� $
��183* ��� $
��105* ��� $
��123* ��� $
��128* �.+��� $��
Поиск��$��5q�$��16(��� $
��5,55q� �� TextWrapping$
 Wrap=�$��16(�$��Stretch=�$��Center=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите ФИО...��$��30������ *Search+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��.+��� $&�� Сортировка по ФИО��$��16(�$��5q�	� -    	�Name$ 	Ascending��$!��По возрастанию��$��16(� 	� 	GroupName$ A�� d� 	IsChecked �� *IsAscending+	� -   $ 
Descending��$��По убыванию��$��16(�$ A�� �� *IsDescending+�� $��Пол��$��5q�$��16(�$��2��$��1���� $
��5,55q�$��2��$ Выберите пол��$��16(�$��1�� �� *SelectedGender+���� *	Genders+�� $��Роль��$��5q�$��16(�$��3��$��1���� $
��5,55q�$��3��$ Выберите роль��$��16(�$��1�� �� *SelectedRole+���� *Roles+�� -   $	 Select��$��3��$��
189,8,0,10q�
�������$
��Left=�$	��165��$#��Выбрать доктора��$
��Auto��y��� *SelectVisibility+�� -   $	 AddNewEmployee��$��3��$��	0,8,20,10q�
�������$��Right=�$	��182��$+��%Добавить сотрудника��$
��Auto���� -   $	 EditEmployee��$��3��$��
0,8,207,10q�
�������$��Right=�$	��214��$5��/Редактировать сотрудника��$
��Auto���� -   $	 RemoveEmployee��$��3��$��
0,8,426,10q�
�������$��Right=�$	��184��$)��#Удалить сотрудника��$
��Auto���� -   $
	 Back��$��3��$��	20,8,0,10q�
�������$
��Left=�$	��164��$��
Назад��$
��Auto��