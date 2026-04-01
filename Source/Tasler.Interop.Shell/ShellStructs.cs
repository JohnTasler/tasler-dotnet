using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Tasler.Interop.Gdi;
using Tasler.SuppressMessage;

namespace Tasler.Interop.Shell;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public struct SHFILEINFOW
{
	public nint hIcon;
	public int iIcon;
	public SFGAO attributes;
	public CharBuffer262 displayName;
	public CharBuffer82 typeName;
};

[StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Unicode)]
public struct CharBuffer262
{
	public char C00, C01, C02, C03, C04, C05, C06, C07, C08, C09, C0A, C0B, C0C, C0D, C0E, C0F;
	public char C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C1A, C1B, C1C, C1D, C1E, C1F;
	public char C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C2A, C2B, C2C, C2D, C2E, C2F;
	public char C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C3A, C3B, C3C, C3D, C3E, C3F;
	public char C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C4A, C4B, C4C, C4D, C4E, C4F;
	public char C50, C51, C52, C53, C54, C55, C56, C57, C58, C59, C5A, C5B, C5C, C5D, C5E, C5F;
	public char C60, C61, C62, C63, C64, C65, C66, C67, C68, C69, C6A, C6B, C6C, C6D, C6E, C6F;
	public char C70, C71, C72, C73, C74, C75, C76, C77, C78, C79, C7A, C7B, C7C, C7D, C7E, C7F;
	public char C80, C81, C82, C83, C84, C85, C86, C87, C88, C89, C8A, C8B, C8C, C8D, C8E, C8F;
	public char C90, C91, C92, C93, C94, C95, C96, C97, C98, C99, C9A, C9B, C9C, C9D, C9E, C9F;
	public char CA0, CA1, CA2, CA3, CA4, CA5, CA6, CA7, CA8, CA9, CAA, CAB, CAC, CAD, CAE, CAF;
	public char CB0, CB1, CB2, CB3, CB4, CB5, CB6, CB7, CB8, CB9, CBA, CBB, CBC, CBD, CBE, CBF;
	public char CC0, CC1, CC2, CC3, CC4, CC5, CC6, CC7, CC8, CC9, CCA, CCB, CCC, CCD, CCE, CCF;
	public char CD0, CD1, CD2, CD3, CD4, CD5, CD6, CD7, CD8, CD9, CDA, CDB, CDC, CDD, CDE, CDF;
	public char CE0, CE1, CE2, CE3, CE4, CE5, CE6, CE7, CE8, CE9, CEA, CEB, CEC, CED, CEE, CEF;
	public char CF0, CF1, CF2, CF3, CF4, CF5, CF6, CF7, CF8, CF9, CFA, CFB, CFC, CFD, CFE, CFF;
	public char C100, C101, C102, C103, C104, C105;
}

[StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Unicode)]
public struct CharBuffer82
{
	public char C00, C01, C02, C03, C04, C05, C06, C07, C08, C09, C0A, C0B, C0C, C0D, C0E, C0F;
	public char C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C1A, C1B, C1C, C1D, C1E, C1F;
	public char C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C2A, C2B, C2C, C2D, C2E, C2F;
	public char C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C3A, C3B, C3C, C3D, C3E, C3F;
	public char C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C4A, C4B, C4C, C4D, C4E, C4F;
	public char C50, C51, C52, C53, C54, C55, C56, C57, C58, C59, C5A, C5B, C5C, C5D, C5E, C5F;
	public char C60, C61, C62, C63, C64, C65, C66, C67, C68, C69, C6A, C6B, C6C, C6D, C6E, C6F;
	public char C70, C71, C72, C73, C74, C75, C76, C77, C78, C79, C7A, C7B, C7C, C7D, C7E, C7F;
	public char C80;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public struct IMAGEINFO
{
	nint hbmImage;
	nint hbmMask;
	int Unused1;
	int Unused2;
	RECT rcImage;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public struct IMAGELISTDRAWPARAMS
{
	uint cbSize;
	nint himl;
	int i;
	nint hdcDst;
	int x;
	int y;
	int cx;
	int cy;
	int xBitmap;        // x offest from the upperleft of bitmap
	int yBitmap;        // y offset from the upperleft of bitmap
	COLORREF rgbBk;
	COLORREF rgbFg;
	uint fStyle;
	uint dwRop;
	uint fState;
	uint Frame;
	COLORREF crEffect;
}
