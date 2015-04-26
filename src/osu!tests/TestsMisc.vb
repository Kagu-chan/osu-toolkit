Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports osutoolkit
Imports NUnit.Framework

Namespace osutest

    <TestFixture()>
    Public Class TestsMisc

        <Test()>
        Public Sub OsuPath()
            Dim path As String = Misc.OsuPath
            Assert.AreEqual("C:\Program Files\osu!", path)
        End Sub

        <Test()>
        Public Sub SkinsPath()
            Dim path As String = Misc.SkinsPath
            Assert.AreEqual("C:\Program Files\osu!\Skins", path)
        End Sub

        <Test()>
        Public Sub ExportsPath()
            Dim path As String = Misc.ExportsPath
            Assert.AreEqual("C:\Program Files\osu!\Exports", path)
        End Sub

        <Test()>
        Public Sub SongsPath()
            Dim path As String = Misc.SongsPath
            Assert.AreEqual("C:\Program Files\osu!\Songs", path)
        End Sub

        <Test()>
        Public Sub Path()
            Dim path As String = Misc.Path("Test")
            Assert.AreEqual("C:\Program Files\osu!\Test", path)
        End Sub

        <Test()>
        Public Sub LoadUserPreferences()
            Misc.LoadUserPreferences()
            Assert.AreEqual("1", Misc.UserPreferences("ChatHighlightName"))
            Assert.AreEqual("WidescreenConservative", Misc.UserPreferences("ScaleMode"))
        End Sub

        <Test()>
        Public Sub LoadUserPreferencesParameterized()
            Misc.LoadUserPreferences({"MenuSnow"})
            Assert.AreEqual("0", Misc.UserPreferences("MenuSnow"))
        End Sub

        <Test()>
        Public Sub StringSetting()
            Misc.LoadUserPreferences()
            Assert.AreEqual("Symmetrical", Misc.StringSetting("ManiaKeyStyle"))
        End Sub

        <Test()>
        Public Sub IntSetting()
            Misc.LoadUserPreferences()
            Assert.AreEqual(90, Misc.IntSetting("DimLevel"))
        End Sub

        <Test()>
        Public Sub DblSetting()
            Misc.LoadUserPreferences()
            Assert.AreEqual(0.5, Misc.DblSetting("CursorSize"))
        End Sub

        <Test()>
        Public Sub BoolSetting()
            Misc.LoadUserPreferences()
            Assert.IsFalse(Misc.BoolSetting("DisplayCityLocation"))
        End Sub

        <Test()>
        Public Sub GetUserName()
            Dim userName As String = Misc.GetUserName
            Assert.AreEqual("Kagu-chan", userName)
        End Sub

    End Class

End Namespace
