using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace CLTokenFieldView
{
	// @protocol CLBackspaceDetectingTextFieldDelegate <UITextFieldDelegate>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface CLBackspaceDetectingTextFieldDelegate : IUITextFieldDelegate
	{
		// @required -(void)textFieldDidDeleteBackwards:(UITextField * _Nonnull)textField;
		[Abstract]
		[Export("textFieldDidDeleteBackwards:")]
		void TextFieldDidDeleteBackwards(UITextField textField);
	}

	// @interface CLBackspaceDetectingTextField : UITextField <UIKeyInput>
	[BaseType(typeof(UITextField))]
	interface CLBackspaceDetectingTextField : IUIKeyInput
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		CLBackspaceDetectingTextFieldDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<CLBackspaceDetectingTextFieldDelegate> * _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @interface CLToken : NSObject
	[BaseType(typeof(NSObject))]
	interface CLToken
	{
		// @property (copy, nonatomic) NSString * _Nonnull displayText;
		[Export("displayText")]
		string DisplayText { get; set; }

		// @property (nonatomic, strong) NSObject * _Nullable context;
		[NullAllowed, Export("context", ArgumentSemantic.Strong)]
		NSObject Context { get; set; }

		// -(id _Nonnull)initWithDisplayText:(NSString * _Nonnull)displayText context:(NSObject * _Nullable)context;
		[Export("initWithDisplayText:context:")]
		IntPtr Constructor(string displayText, [NullAllowed] NSObject context);
	}

	// @protocol CLTokenViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface CLTokenViewDelegate
	{
		// @required -(void)tokenViewDidRequestDelete:(CLTokenView * _Nonnull)tokenView replaceWithText:(NSString * _Nullable)replacementText;
		[Abstract]
		[Export("tokenViewDidRequestDelete:replaceWithText:")]
		void TokenViewDidRequestDelete(CLTokenView tokenView, [NullAllowed] string replacementText);

		// @required -(void)tokenViewDidRequestSelection:(CLTokenView * _Nonnull)tokenView;
		[Abstract]
		[Export("tokenViewDidRequestSelection:")]
		void TokenViewDidRequestSelection(CLTokenView tokenView);
	}

	// @interface CLTokenView : UIView <UIKeyInput>
	[BaseType(typeof(UIView))]
	interface CLTokenView : IUIKeyInput
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		CLTokenViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<CLTokenViewDelegate> * _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { get; set; }

		// @property (assign, nonatomic) BOOL hideUnselectedComma;
		[Export("hideUnselectedComma")]
		bool HideUnselectedComma { get; set; }

		// -(id _Nonnull)initWithToken:(CLToken * _Nonnull)token font:(UIFont * _Nullable)font;
		[Export("initWithToken:font:")]
		IntPtr Constructor(CLToken token, [NullAllowed] UIFont font);

		// -(void)setSelected:(BOOL)selected animated:(BOOL)animated;
		[Export("setSelected:animated:")]
		void SetSelected(bool selected, bool animated);

		// -(void)setTintColor:(UIColor * _Nullable)tintColor;
		[Export("setTintColor:")]
		void SetTintColor([NullAllowed] UIColor tintColor);
	}

	// @protocol CLTokenInputViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface CLTokenInputViewDelegate
	{
		// @optional -(void)tokenInputViewDidEndEditing:(CLTokenInputView * _Nonnull)view;
		[Export("tokenInputViewDidEndEditing:")]
		void TokenInputViewDidEndEditing(CLTokenInputView view);

		// @optional -(void)tokenInputViewDidBeginEditing:(CLTokenInputView * _Nonnull)view;
		[Export("tokenInputViewDidBeginEditing:")]
		void TokenInputViewDidBeginEditing(CLTokenInputView view);

		// @optional -(BOOL)tokenInputViewShouldReturn:(CLTokenInputView * _Nonnull)view;
		[Export("tokenInputViewShouldReturn:")]
		bool TokenInputViewShouldReturn(CLTokenInputView view);

		// @optional -(void)tokenInputView:(CLTokenInputView * _Nonnull)view didChangeText:(NSString * _Nullable)text;
		[Export("tokenInputView:didChangeText:")]
		void DidChangeText(CLTokenInputView view, [NullAllowed] string text);

		// @optional -(void)tokenInputView:(CLTokenInputView * _Nonnull)view didAddToken:(CLToken * _Nonnull)token;
		[Export("tokenInputView:didAddToken:")]
		void DidAddToken(CLTokenInputView view, CLToken token);

		// @optional -(void)tokenInputView:(CLTokenInputView * _Nonnull)view didRemoveToken:(CLToken * _Nonnull)token;
		[Export("tokenInputView:didRemoveToken:")]
		void DidRemoveToken(CLTokenInputView view, CLToken token);

		// @optional -(CLToken * _Nullable)tokenInputView:(CLTokenInputView * _Nonnull)view tokenForText:(NSString * _Nonnull)text;
		[Export("tokenInputView:tokenForText:")]
		[return: NullAllowed]
		CLToken TokenForText(CLTokenInputView view, string text);

		// @optional -(void)tokenInputView:(CLTokenInputView * _Nonnull)view didChangeHeightTo:(CGFloat)height;
		[Export("tokenInputView:didChangeHeightTo:")]
		void DidChangeHeightTo(CLTokenInputView view, nfloat height);
	}

	// @interface CLTokenInputView : UIView <CLBackspaceDetectingTextFieldDelegate, CLTokenViewDelegate>
	[BaseType(typeof(UIView))]
	interface CLTokenInputView : CLBackspaceDetectingTextFieldDelegate, CLTokenViewDelegate
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		CLTokenInputViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<CLTokenInputViewDelegate> * _Nullable delegate __attribute__((iboutlet));
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable fieldView;
		[NullAllowed, Export("fieldView", ArgumentSemantic.Strong)]
		UIView FieldView { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable fieldName;
		[NullAllowed, Export("fieldName")]
		string FieldName { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable fieldColor;
		[NullAllowed, Export("fieldColor", ArgumentSemantic.Strong)]
		UIColor FieldColor { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable placeholderText;
		[NullAllowed, Export("placeholderText")]
		string PlaceholderText { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable accessoryView;
		[NullAllowed, Export("accessoryView", ArgumentSemantic.Strong)]
		UIView AccessoryView { get; set; }

		// @property (assign, nonatomic) UIKeyboardType keyboardType;
		[Export("keyboardType", ArgumentSemantic.Assign)]
		UIKeyboardType KeyboardType { get; set; }

		// @property (assign, nonatomic) UITextAutocapitalizationType autocapitalizationType;
		[Export("autocapitalizationType", ArgumentSemantic.Assign)]
		UITextAutocapitalizationType AutocapitalizationType { get; set; }

		// @property (assign, nonatomic) UITextAutocorrectionType autocorrectionType;
		[Export("autocorrectionType", ArgumentSemantic.Assign)]
		UITextAutocorrectionType AutocorrectionType { get; set; }

		// @property (assign, nonatomic) UIKeyboardAppearance keyboardAppearance;
		[Export("keyboardAppearance", ArgumentSemantic.Assign)]
		UIKeyboardAppearance KeyboardAppearance { get; set; }

		// @property (nonatomic, strong) NSMutableArray<CLToken *> * _Nonnull tokens;
		[Export("tokens", ArgumentSemantic.Strong)]
		NSMutableArray Tokens { get; set; }

		// @property (nonatomic, strong) NSMutableArray<CLTokenView *> * _Nonnull tokenViews;
		[Export("tokenViews", ArgumentSemantic.Strong)]
		NSMutableArray<CLTokenView> TokenViews { get; set; }

		// @property (nonatomic, strong) CLBackspaceDetectingTextField * _Nonnull textField;
		[Export("textField", ArgumentSemantic.Strong)]
		CLBackspaceDetectingTextField TextField { get; set; }

		// @property (nonatomic, strong) UILabel * _Nonnull fieldLabel;
		[Export("fieldLabel", ArgumentSemantic.Strong)]
		UILabel FieldLabel { get; set; }

		// @property (assign, nonatomic) CGFloat intrinsicContentHeight;
		[Export("intrinsicContentHeight")]
		nfloat IntrinsicContentHeight { get; set; }

		// @property (assign, nonatomic) CGFloat additionalTextFieldYOffset;
		[Export("additionalTextFieldYOffset")]
		nfloat AdditionalTextFieldYOffset { get; set; }

		// @property (copy, nonatomic) NSSet<NSString *> * _Nonnull tokenizationCharacters;
		[Export("tokenizationCharacters", ArgumentSemantic.Copy)]
		NSSet<NSString> TokenizationCharacters { get; set; }

		// @property (assign, nonatomic) BOOL drawBottomBorder;
		[Export("drawBottomBorder")]
		bool DrawBottomBorder { get; set; }

		// @property (readonly, nonatomic) NSArray<CLToken *> * _Nonnull allTokens;
		[Export("allTokens")]
		CLToken[] AllTokens { get; }

		// @property (readonly, getter = isEditing, nonatomic) BOOL editing;
		[Export("editing")]
		bool Editing { [Bind("isEditing")] get; }

		// @property (readonly, nonatomic) CGFloat textFieldDisplayOffset;
		[Export("textFieldDisplayOffset")]
		nfloat TextFieldDisplayOffset { get; }

		// @property (readonly, nonatomic) NSString * _Nullable text;
		[NullAllowed, Export("text")]
		string Text { get; }

		// -(void)addToken:(CLToken * _Nonnull)token;
		[Export("addToken:")]
		void AddToken(CLToken token);

		// -(void)removeToken:(CLToken * _Nonnull)token;
		[Export("removeToken:")]
		void RemoveToken(CLToken token);

		// -(CLToken * _Nullable)tokenizeTextfieldText;
		[NullAllowed, Export("tokenizeTextfieldText")]
		CLToken TokenizeTextfieldText { get; }

		// -(void)beginEditing;
		[Export("beginEditing")]
		void BeginEditing();

		// -(void)endEditing;
		[Export("endEditing")]
		void EndEditing();
	}
}
