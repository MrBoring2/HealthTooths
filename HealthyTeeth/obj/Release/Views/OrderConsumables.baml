   M S B A M L   `   `   `  ���� G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  )    #HealthyTeeth.Views.OrderConsumables   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:HealthyTeeth.Views     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml    � Title$C  =Здоровые зубы | Заказ расходников��$	��700��$	��900��$	��700��$	��900�� � Icon$0 */HealthyTeeth;component/Resources/logo.ico��.��� 
����ح� � RowDefinitions �� $
��485* ��� $	��100 ��� $	��58* � � ColumnDefinitions �� .+�#  MaterialDesignThemes.Wpf.Card  $��
15,15,15,5q�.���  �� $
��164* ��� $
��141* � �� $	��111 ��� �� $��56 �.+��� $C��=Расходные материалы для доставки��$��20(�$��Center=�$��206,5,206,0q�$	��Top=�$��2��$��27��$	��330���� $(��"Склад для доставки��$��
15,40,0,51q�$��14(��� $��14(� �� DisplayMemberPath$ StorageName��$��15,65,10,10q����� *
Storages+ �� SelectedItem �� *SelectedStorage+�� $��Поставщик��$��
15,40,0,51q�$��14(�$��1���� $��1��$ SupplierName��$��14(�$��15,65,10,10q����� *	Suppliers+ �� *SelectedSupplier+�� $)��#Список расходников��$��1��$��14(�$��Center=�$	��Top=�$��133,0q�$��19��$	��133���� $��Disabled=� �� SelectionMode$ Single=�   listViewItemStype#��[  $��1��$��0��$��
15,20,10,5q�$��1��  deliveryConsumablesList#��[ $��Stretch=� �� *SelectedConsumable+���� *DisplayedConsumables+�� $@��:Список потраченных расходников��$��1��$��1��$��14(�$��Center=�$	��Top=�$��	61,0,60,0q�$��19��$	��222���� $��Disabled=�$��1��$��1��$��
15,20,10,5q�$��1��$ Single=�#��[    spendConsumablesList#��[ $��Stretch=� �� *SelectedSpendConsumable+���� *SpendedConsumables+�� -    ��Name$ 	AddToList��$&�� Добавить в список��$��2��$��0��$	��5,9q�
�������$
��Auto���� -   $ RemoveFromList��$&�� Удалить из списка��$��2��$��1��$	��5,9q�
�������$
��Auto��  $��1��$��15q�.��� .+��� $��Center=�$��Center=�$��26(����� *
TotalPrice+ �� StringFormat$2 ,Полная стоимость: {0} руб.���� -   $
 Back��$��
Назад��
�������$��Right=�$��	0,0,28,10q�$��Bottom=�$	��226��$��2���� -   $ Order��$��Заказать��
�������$
��Left=�$��	28,0,0,10q�$��Bottom=�$	��226��$��2��