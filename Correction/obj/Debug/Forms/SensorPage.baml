   M S B A M L   `   `   `  ����E  ACorrection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Correction.FormsCorrection.Forms  5   	   !    Correction.Forms.SensorPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Correction.Forms     5   	     � Title$  
SensorPage��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��4* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Название��6   $��0��6$    	  TextS#��[  61   6R   �� 5   
   -   5        $��
NameSensor��5   /   $��1��6   $��0��6"     
TextWriteS#��[ 6A   6g   �� 5   
   $��Разрешение��6   $��1��6&   #��[  63   6T   �� 5   
   -   5        $��ResolutionSensor��5   /   $��1��6   $��1��6"   #��[ 6G   6m   �� 5   
   $!��Серийный номер��6   $��2��6*   #��[  67   6X   �� 5   
   -   5        $��SerialNumberSensor��5   /   $��1��6   $��2��6"   #��[ 6I   6o   �� 5   
   $��Описание��6   $��3��6%   $��2��62   .��5      �� -   5         ��Name$ DescriptionSensor��5      63   5       �� 5"   
   $#��Дата добавления��6   $��4��6+   #��[  68   6Y   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ 
DateSensor��5#   2   $��4��6   $��1��6"    	 DateS#��[ 6F   6g   �� 5%   
   -   5        $
��Save��5%   `   $��0��6   $��5��6!   $��Сохранить��6.     ButS#��[ 6B   6�   �� 5&   
   -   5        $��Delete��5&   ^   $��1��6   $��5��6!   $��Удалить��6.   #��[ 6@   6�   5(      5)      