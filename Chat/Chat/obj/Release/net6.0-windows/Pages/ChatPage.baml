   M S B A M L   `   `   `  ���� G  CCachedImage, Version=0.1.15.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  ? ;Chat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Chat.ConvertersChat.Converters 'clr-namespace:Chat.Pages
Chat.Pages /clr-namespace:Chat.SelectorsChat.Selectors    Chat.Pages.ChatPage   Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     FcachedImage.clr-namespace:CachedImage;assembly=CachedImage     .convclr-namespace:Chat.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  $localclr-namespace:Chat.Pages  _	 [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 ,	selectorsclr-namespace:Chat.Selectors 	 -   $
��Chat��  N� Title$  ChatPage��   MaterialDesignPaper N� 
Background# �     MaterialDesignFont N� 
FontFamily# �  $��13(�$��Regular"�  MaterialDesignBody#���  &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=� � DataContext ��   ViewModelLocator �� Source# [  �� Path$ ChatViewModel� J� InputBindings �� 	 �� Gesture$	 Enter��
 �� Command
 �� *SendMessageCommand+ � 	Resources $  Chat.Converters.ImageConverter  	imageconv,  &Chat.Converters.MessageStatusConverter  messageconv&   Chat.Converters.WritingConverter  writconv  UserMessageTemplate �� Orientation# 	 MaterialDesignThemes.Wpf.Card  PrimaryHueLightBrush �� 	Converter �� BitmapScalingMode �� CachingHint j� Stretch �� ImageSource �� IsAsync �� TargetNullValue �� FallbackValue 	 DeclarationTemplate 
 MessageTemplate��%�  &	       &	      &	 
     &	      7  7  &		 k    &	
 0    7        �� .R��� $��Right=�$ 
Horizontal=�.+�  $��0,0,0,10q����#383636.���� $��	10,5,10,5q�$ 
Horizontal=�.+��� .+��� $��Right=�$ 
Horizontal=�.+��� $��0,0,10,0q�
����������� *Time+�� $��0,0,0,5q�$��Medium"�#���  ���� *
Username+�� $��Right=�$��Regular"�$
��Wrap=����� *IsSent+8   ���� *Data+A� $��48��$��48��$��0,0,8,10q�#���  $��2������ $ 
LowQuality=�$ Cache=�$ UniformToFill=� �� *Pic+$
 True��8  $/ )pack://Application:,,,/Resources/user.png��$/ )pack://Application:,,,/Resources/user.png���� .R�  $��0,0,0,10q����#383636.���� $��	10,5,10,5q�$ 
Horizontal=�.+��� $��Medium"�#���  $
��Wrap=����� *Declaration+�� $��10,0,0,0q�
����������� *Time+�� .R��� $ 
Horizontal=�.+�A� $��48��$��48��$��0,0,8,10q�#���  $��2������ $ 
LowQuality=�$ Cache=�$ UniformToFill=� �� *Pic+$
 True��8   $/ )pack://Application:,,,/Resources/user.png��$/ )pack://Application:,,,/Resources/user.png��  $��0,0,0,10q����#383636.���� $��	10,5,10,5q�$ 
Horizontal=�.+��� .+��� $ 
Horizontal=�.+��� $��0,0,0,5q�$��Medium"�#���  ���� *
Username+�� $��10,0,0,0q�
����������� *Time+�� $��Regular"�$
��Wrap=����� *Data+.��� .+��  � ColumnDefinitions �� $	��230 ��� $��3* � � RowDefinitions �� �� $��40 �.+�  $��0��$��1��$��5q�   UniformCornerRadius$ 5Q�.���� -    ��Name$ Scroller��$��10q�$
��True��$
��Auto=�.���� -    ��Name$ messages������ *
Messages+��$  Chat.Selectors.MessageSelector     DeclarationTemplate# [	    MessageTemplate# [
    UserMessageTemplate# [ �� $��1��$��30��$��5q����� *ConnectToServerCommand+.��' 	 !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
Connection=��  �� $��39 ��� $��39 ��� $
��326* �.+��� $��30��$��5q����� *ShowSettings+.��  $ Settings=��� $��1��$��30��$��5q����� *DisconnectFromServerCommand+.��  $ LanDisconnect=�  $��2��$��5,5,5,5q�$��Stretch=�$ 5Q�.���� -   $��Nicks��$��Stretch=����� *Nicks+���� .R�  $��5q�$��5q����#383636.��� $��Stretch=� �� $��* ��� .+��� $��0��$��SemiBold"�$��CharacterEllipsis=����� *Nick+�� $��1��$��Right=�$��SemiBold"�$��CharacterEllipsis=����� *	IsWriting+# [ � $��1��$��1�� �� $��8* ��� .+��� -   $��messagefield��$��5q�) 	 #MaterialDesignThemes.Wpf.HintAssist   Hint$ Сообщение��.	 	 (MaterialDesignThemes.Wpf.TextFieldAssist 	  HasLeadingIcon$
 True��  	  LeadingIcon$  Message=�! �� 	MaxLength$	! 500��" �� TextWrapping$
" Wrap=����� *	Message+# �� UpdateSourceTrigger$# PropertyChanged=�.��*
  $Microsoft.Xaml.Behaviors.Interaction$ 
  Triggers$ +  %Microsoft.Xaml.Behaviors.EventTrigger  %   	EventName$% TextChanged��*  $Microsoft.Xaml.Behaviors.TriggerBase&   Actions.& 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  '   Command' �� *SendWritingCommand+.���� $��1��$��30��$��5q�$��Stretch=����� *SendMessageCommand+.��  $
 Send=�) 	 #MaterialDesignThemes.Wpf.DialogHost  (   CloseOnClickAway$
( True��)   
Identifier$) Settings��*   IsOpen* �� *IsSettingsOpen++   DialogContentTemplate+ �� .R�  $	��300��$
��Auto��.���� $��5q� �� , �� ElementName$
, Chat��$  DataContext.ConnectionData�.+��� $��0,0,0,5q�$ IP��$
 True��$  Ip=����� *IP+$# PropertyChanged=��� $��0,0,0,5q�$ Порт��$
 True��$  Numbers=����� *Port+$# PropertyChanged=�$  ��- �� NotifyOnValidationError$- False���� $��2��$��0,0,0,5q�$ Ник��$
 True��$
  User=����� *Nick+$# PropertyChanged=��� $��2��$��0,0,0,15q�$ Аватарка��$
 True��$  Picture=����� *	UserPic+$# PropertyChanged=��� $	��200��$��0,0,0,10q�$��Сохранить������ $
, Chat��$ DataContext.SaveSettings�