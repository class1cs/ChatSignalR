   M S B A M L   `   `   `  ����G  CCachedImage, Version=0.1.15.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  5      ? ;Chat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Chat.ConvertersChat.Converters 5      'clr-namespace:Chat.Pages
Chat.Pages 5	      /clr-namespace:Chat.SelectorsChat.Selectors 5         Chat.Pages.ChatPage   5      Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      FcachedImage.clr-namespace:CachedImage;assembly=CachedImage     5      .convclr-namespace:Chat.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      $localclr-namespace:Chat.Pages  5	      _	 [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5      ,	selectorsclr-namespace:Chat.Selectors 	 5      -   5        $
��Chat��5        N� Title$  ChatPage��5         MaterialDesignPaper N� 
Background# �   5        MaterialDesignFont N� 
FontFamily# �  5      $��13(�5      $��Regular"�5        MaterialDesignBody#���  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5       � DataContext 5      ��   ViewModelLocator �� Source# [  �� Path$ ChatViewModel� J� InputBindings 5      �� 5   
   	 �� Gesture$	 Escape��6?   
 �� Command
 6   �� *ClosePhotoViewCommand+6?    � 	Resources 5      $  Chat.Converters.ImageConverter  	imageconv&   Chat.Converters.WritingConverter  writconv)  #Chat.Converters.ImageWidthConverter  ImageWidthConverter0  *Chat.Converters.FromBytestoBitmapConverter  FromBytesToBitmapConverter  DeclarationTemplate# 	 MaterialDesignThemes.Wpf.Card �� Orientation 	 PrimaryHueLightBrush 
 ImageMessageTemplate �� BitmapScalingMode �� CachingHint j� Stretch �� ImageSource �� IsAsync �� 	Converter �� TargetNullValue �� FallbackValue   CachedImage.Image � Cursor d� MouseAction%  System.Windows.Markup.Reference �� CommandParameter �� ElementName � ContextMenu m� Command m� CommandParameter  MessageTemplate��%�  &	       &	      &	 &     &	 9     &	 L     &	
 �    7  7  7  &	 �    7    5   
   6     5    
   6      5!   
   6#     5"   
   6*   �� 5#   
   .R�5$        $��0,0,0,10q�6"   ���#383636.��5%      �� $��	10,5,10,5q�6   $ 
Horizontal=�60   .+�5(      �� $��Medium"�5)      #��� 	 5*      $
��Wrap=�5,      ��5+      �� * DeclarationMessage.Declaration+5,      �� 5-      $��10,0,0,0q�5.      
���������50      �� *DeclarationMessage.Time+51      52      53      �� 58   
   .R�59      �� $
��Left=�6   $ 
Horizontal=�64   .+�5:      A� $��48��5;      $��48��5<      $��0,0,8,10q�5=      #��� 	 5>      $��2��5?      ��5@      �� 5A      $ 
LowQuality=�5C      $ Cache=�5D      $ UniformToFill=�5E       5B      �� *ImageMessage.UserPic+$
 True��8   $/ )pack://Application:,,,/Resources/user.png��$/ )pack://Application:,,,/Resources/user.png��5E      5G        5H      $��0,0,0,10q�6&   ���#383636.��5I      �� $��	10,5,10,5q�6!   $ 
Horizontal=�64   .+�5K      �� .+�5L      �� $
��left=�6)   $ 
Horizontal=�6D   .+�5M   "   �� $��0,0,0,5q�5N   %   $��Medium"�5O   %   #��� 	 5P   %   ��5Q   %   �� *ImageMessage.Username+�� 5R   "   $��10,0,0,0q�5S   %   
���������5U   %   �� *ImageMessage.Time+5X        5Z      $��ImageFromUser��5a   !   $
 Hand��5]   !   $��Stretch=�5^      $��Stretch=�5_   !   $
 Fant=�5b   !   ��5`   !   �� *ImageMessage.AddedImage+8  ��5c   !   �� *ImageMessage.AddedImage+8   5e   "   d� 5f   &   $ LeftDoubleClicke�63   
 5g      ��    *
maingrid+$" DataContext.ShowImageCommand� 5h      �� $ ImageFromUser��$ Source� 5j   "   �� 5k   &   .@�5l   *   m� $��Скачать��5o   -    5m   -   ��    *
maingrid+$&  DataContext.DownloadImageCommand� 5n   -   �� 5o   -   5q   '   5s      5t      5v      5w      5y      5z      �� 5}   
   .R�5~      �� $ 
Horizontal=�6   .+�5�      A� $��48��5�      $��48��5�      $��0,0,8,10q�5�      #��� 	 5�      $��2��5�      ��5�      �� 5�      $ 
LowQuality=�5�      $ Cache=�5�      $ UniformToFill=�5�       5�      �� *TextMessage.UserPic+$
 True��8   $/ )pack://Application:,,,/Resources/user.png��$/ )pack://Application:,,,/Resources/user.png��5�      5�        5�      $��0,0,0,10q�6&   ���#383636.��5�      �� $��	10,5,10,5q�6!   $ 
Horizontal=�64   .+�5�      �� .+�5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��0,0,0,5q�5�   %   $��Medium"�5�   %   #��� 	 5�   %   ��5�   %   �� *TextMessage.Username+�� 5�   "   $��10,0,0,0q�5�   %   
���������5�   %   �� *TextMessage.Time+5�      �� 5�      $��Regular"�5�   !   $	��300��5�   #   $��WrapWithOverflow=�5�   !   ��5�   !   �� *TextMessage.Data+5�   !   5�      5�      5�      5�      5�      5�      .��5�      � -   5        $��maingrid��5�      .+�5�   
   �  � ColumnDefinitions 5�      �� 5�      $	��230 �6#   �� 5�      $��3* �6#    � RowDefinitions 5�      �� 5�      �� 5�      $��40 �6    .+�5�        $��0��5�      $��1��5�      $��5q�5�         UniformCornerRadius$ 5Q�5�      .��5�      �� -   5         ��Name$ Scroller��5�      $��10q�5�      $
��True��5�      $
��Auto=�5�      .��5�      �� -   5          ��Name$  messages��5�   #   ��65   �� *
Messages+��5�      ,	  &Chat.Selectors.MessageTemplateSelector	  5�      ! 	  DeclarationTemplate#! [ 5�   !   " 	  ImageMessageTemplate#" [
 5�   !   # 	  MessageTemplate## [ 5�   !   5�      5�      5�      �� 5�      $��1��5�      $��30��5�      $��5q�5�      ��5�      �� *ConnectToServerCommand+.��5�      '
 	 !MaterialDesignThemes.Wpf.PackIcon
  $ 
  Kind$$ 
Connection=�6*   5�      � 5�       5�      �� 5�      $��39 �6$   �� 5�      $��39 �6$   �� 5�      $
��326* �6$   .+�5�      �� $��30��5�      $��5q�5�      ��5�      �� *ShowSettings+.��5�      
  $$ Settings=�6.   5�      �� 5�      $��1��5�      $��30��5�      $��5q�5�      ��5�      �� *DisconnectFromServerCommand+.��5�      
  $$ LanDisconnect=�6.   5�        5�      $��2��5�      $��5,5,5,5q�5�      $��Stretch=�5�      $ 5Q�5�      .��5�      �� -   5        $��Nicks��5�      $��Stretch=�5�      ��5�      �� *Nicks+��5     �� 5     .R�5  "     $��5q�5  %   $��5q�5  %   ���#383636.��5
  &   �� $ 
Horizontal=�61   .+�5  *   A� $��48��5  -   $��48��5  -   $��5q�5  -   #��� 	 5  -   $��2��5  -   ��5  .   �� 5  2   $ 
LowQuality=�5  5   $ Cache=�5  5   $ UniformToFill=�5  5    5  5   �� *Pic+# [ $/ )pack://Application:,,,/Resources/user.png��$/ )pack://Application:,,,/Resources/user.png��5  5   5  +   � 5  *   $��10,5,0,0q�6/   $��Stretch=�6A    5  .   �� 5  2   $��* �6@   �� 5  2   .+�5  .   �� $��0��5   1   $��15(�5!  1   $��SemiBold"�5"  1   $��CharacterEllipsis=�5$  1   ��5#  1   �� *Nick+5$  1   �� 5%  .   $��Writing��5&  1   $��1��5'  1   $��13(�5(  1   $��SemiBold"�5)  1   ���#9c9c9c$��CharacterEllipsis=�5,  1   ��5+  1   �� *	IsWriting+# [ % � Triggers% 5-  2   :� 5.  6   & :� RoutedEvent$& Loaded��6C   .[�5/  :   �� .��50  >   �� .��51  B   W� ' �� 
TargetName$' Writing��52     ( �� TargetProperty$( (TextBlock.Opacity)�53     ) W� From) 1.054     	* W� To* 0.06   + g� Duration$+ 0:0:1D�6!   , g� AutoReverse$
, True��55     - g� RepeatBehavior$- Forever��6    56  ?   57  ;   58  7   5:  /   5;  +   5<  '   5=  #   5@     5B     5C     5E     � 5H     $��1��6   $��1��6     5I     �� 5J     �� 5K     $��63.333 �6'   �� 5L     $��62.959 �6'   .+�5O     �� -   5        $��messagefield��5P     $��5q�5Q     ) 	 #MaterialDesignThemes.Wpf.HintAssist.   Hint$. Сообщение��5R     . 	 (MaterialDesignThemes.Wpf.TextFieldAssist/   HasLeadingIcon$
/ True��5S     0   LeadingIcon$0 Message=�5T     1 �� AcceptsReturn$
1 True��5U     2 �� 	MaxLength$	2 500��5V     3 �� TextWrapping$
3 Wrap=�5Z     ��5Y     �� *	Message+4 �� UpdateSourceTrigger$4 PropertyChanged=�.��5Z  )   *  $Microsoft.Xaml.Behaviors.Interaction5   Triggers5 5[     +  %Microsoft.Xaml.Behaviors.EventTrigger  5\     6   	EventName$6 TextChanged��6)   *  $Microsoft.Xaml.Behaviors.TriggerBase7   Actions.7 5]     2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  8   Command8 64   �� *SendWritingCommand+5^     .��5`  .    5a     �� 5b     $	 Enter��6L   
 6%   �� *SendMessageCommand+6L   .��5c  -   5d     �� 5e     $��1��5f     $��30��5g     $��5q�5h     $��Stretch=�5i     ��5j     �� *SendImageCommand+.��5k     
  $$ ImageAdd=�6.   5l     �� 5m     $��2��5n     $��30��5o     $��5q�5p     $��Stretch=�5q     ��5r     �� *SendMessageCommand+.��5s     
  $
$ Send=�6.   5t     5u     5w     ) 	 #MaterialDesignThemes.Wpf.DialogHost  5x  
   9   CloseOnClickAway$
9 True��6$   :   
Identifier$: ViewerWindow��5y     $
��Auto��5z     $
��Auto��6%   5~       5�  
   $
9 True��5�     $: Settings��5�     ;   IsOpen; 5�     �� *IsSettingsOpen+<   DialogContentTemplate< 5�     �� 5�     .R�5�       $	��300��6*   $
��Auto��66   .��5�     �� $��5q�6%    60   �� $
 Chat��$  DataContext.ConnectionData�.+�5�     �� $��0,0,0,5q�5�  !   $. IP��5�  !   $
/ True��5�  !   $0 Ip=�5�  !   ��5�  !   �� *IP+$4 PropertyChanged=��� 5�     $��0,0,0,5q�5�  !   $. Порт��5�  !   $
/ True��5�  !   $0 Numbers=�5�  !   ��5�  !   �� *Port+$4 PropertyChanged=�$  ��= �� NotifyOnValidationError$= False���� 5�     $��2��5�  !   $��0,0,0,5q�5�  !   $. Ник��5�  !   $
/ True��5�  !   $
0 User=�5�  !   ��5�  !   �� *Nick+$4 PropertyChanged=��� 5�     $��2��5�  !   $��0,0,0,15q�5�  !   $. Аватарка��5�  !   $
/ True��5�  !   $0 Picture=�5�  !   ��5�  !   �� *	UserPic+$4 PropertyChanged=��� 5�     $	��200��5�  !   $��0,0,0,10q�5�  !   $��Сохранить��5�  !   ��5�  !   �� $
 Chat��$ DataContext.SaveSettings�5�  !   5�     5�     5�     5�     5�     5�     