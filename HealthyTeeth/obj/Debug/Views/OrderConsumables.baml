   M S B A M L   `   `   `  ����G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  5   	   )    #HealthyTeeth.Views.OrderConsumables   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HealthyTeeth.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5   	     � WindowStartupLocation$  CenterScreen=�5	       � Title$C =Здоровые зубы | Заказ расходников��5
   	   $	��700��63   $	��900��6@   $	��700��6L   $	��900��6\    � Icon$0 */HealthyTeeth;component/Resources/logo.ico��6k   .��5      � 
����ح� � RowDefinitions 5   
   �� 5      $
��485* �6   �� 5      $	��100 �6   �� 5      $	��58* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��
15,15,15,5q�6   .��5      �  5      �� 5      $
��164* �6'   �� 5      $
��141* �6'    5      �� 5      $	��111 �6$   �� 5      �� 5      $��56 �6$   .+�5      �� $C��=Расходные материалы для доставки��6   $��20(�6D   $��Center=�6R   $��206,5,206,0q�6o   $	��Top=�6�   $��2��6�   $��27��6�   $	��330��6�   �� 5       $(��"Склад для доставки��6   $��
15,40,0,51q�66   $��14(�6J   �� 5!      $��14(�6<    �� DisplayMemberPath$ StorageName��6J   $��15,65,10,10q�6�   ��6   �� *
Storages+ �� SelectedItem 6j   �� *SelectedStorage+6�   �� 5#      $��Поставщик��6   $��
15,40,0,51q�6-   $��14(�6A   $��1��6O   �� 5$      $��1��6=   $ SupplierName��6x   $��14(�6�   $��15,65,10,10q�6�   ��6   �� *	Suppliers+ 6N   �� *SelectedSupplier+6�   �� 5&      $)��#Список расходников��6   $��1��66   $��14(�6C   $��Center=�6Q   $	��Top=�6n   $��133,0q�6�   $��19��6�   $	��133��6�   �� 5'      $��Disabled=�6    �� SelectionMode$ Single=�6Q      listViewItemStype#��[  6�   $��1��6�   $��0��6�   $��
15,20,10,5q�6�   $��1��6�     deliveryConsumablesList#��[ 6;  $��Stretch=�6s   6h   �� *SelectedConsumable+��6  �� *DisplayedConsumables+6s  �� 5(      $@��:Список потраченных расходников��6   $��1��6B   $��1��6O   $��14(�6_   $��Center=�6m   $	��Top=�6�   $��	61,0,60,0q�6�   $��19��6�   $	��222��6�   �� 5)      $��Disabled=�6   $��1��6Q   $��1��6^   $��
15,20,10,5q�6n   $��1��6�   $ Single=�6�   #��[  6�     spendConsumablesList#��[ 6?  $��Stretch=�6t   6�   �� *SelectedSpendConsumable+��6  �� *SpendedConsumables+6t  �� 5*      -   5         ��Name$ 	AddToList��5*      $&�� Добавить в список��6,   $��2��6H   $��0��6U   $	��5,9q�6e   
�������$
��Auto��6�   �� 5+      -   5        $ RemoveFromList��5+      $&�� Удалить из списка��61   $��2��6M   $��1��6Z   $	��5,9q�6j   
�������$
��Auto��6�   5,      5-        5/   
   $��1��6   $��15q�6%   .��50      � .+�51      �� $��Center=�6   $��Center=�69   $��26(�6T   ��6b   �� *
TotalPrice+	 �� StringFormat$2	 ,Полная стоимость: {0} руб.��52      53      �� 55   
   -   5        $
 Back��55      $��
Назад��6   
�������$��Right=�6B   $��	0,0,28,10q�6^   $��Bottom=�6q   $	��226��6�   $��2��6�   �� 56   
   -   5        $ Order��56      $��Заказать��6    
�������$
��Left=�6F   $��	28,0,0,10q�6a   $��Bottom=�6t   $	��226��6�   $��2��6�   57      58      