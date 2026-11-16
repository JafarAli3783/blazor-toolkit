# SfSidebar API XML Documentation Reference

> **Component:** `SfSidebar`  
> **Namespace:** `Syncfusion.Blazor.Toolkit`  
> **Specification Source:** [`API.md`](./API.md)  
> **Documentation Standard:** Microsoft C# XML Documentation & Syncfusion Blazor Toolkit Standards

---

## Table of Contents

1. [Component Class (`SfSidebar`)](#1-component-class-sfsidebar)
2. [Enumerations](#2-enumerations)
   - [`SidebarMode`](#21-sidebarmode)
   - [`SidebarPosition`](#22-sidebarposition)
   - [`SidebarBreakpoint`](#23-sidebarbreakpoint)
3. [Component Parameters (Properties)](#3-component-parameters-properties)
4. [Events & Event Arguments](#4-events--event-arguments)
   - [Event Callbacks](#41-event-callbacks)
   - [`SidebarEventArgs`](#42-sidebareventargs)
5. [Public Instance Methods](#5-public-instance-methods)
6. [Public CSS Classes, Accessibility & Localization Reference](#6-public-css-classes-accessibility--localization-reference)

---

## 1. Component Class (`SfSidebar`)

```csharp
using Microsoft.AspNetCore.Components;

namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// Represents a collapsible side panel component used for primary navigation, contextual tools, or secondary content.
    /// </summary>
    /// <remarks>
    /// <para>The <see cref="SfSidebar"/> component supports multiple docking and display behaviors including <see cref="SidebarMode.Overlay"/>, <see cref="SidebarMode.Push"/>, and <see cref="SidebarMode.Shrink"/>. It provides built-in responsive breakpoint handling, a collapsed mini-rail state (<see cref="EnableMini"/>), logical inline positioning (<see cref="SidebarPosition.Start"/> and <see cref="SidebarPosition.End"/>) with automatic Right-to-Left (RTL) adaptation, and smooth CSS transitions honoring the user's <c>prefers-reduced-motion</c> setting.</para>
    /// <para>The component is designed with accessibility-first semantics, automatically applying appropriate WAI-ARIA roles (<c>dialog</c> with <c>aria-modal="true"</c> in modal overlay mode, or <c>navigation</c> / <c>complementary</c> in docked modes), focus management, backdrop dismissal, and keyboard navigation (<c>Escape</c> key support).</para>
    /// <para>For standalone layouts where <see cref="TargetContent"/> is not supplied, the component exposes the <c>--e-sidebar-occupied-width</c> CSS custom property and public CSS class hooks (<c>e-sidebar</c>, <c>e-sidebar-open</c>, <c>e-sidebar-mini</c>, <c>e-sidebar-overlay</c>, <c>e-sidebar-push</c>, <c>e-sidebar-shrink</c>, <c>e-sidebar-left</c>, <c>e-sidebar-right</c>, <c>e-sidebar-backdrop</c>, <c>e-sidebar-header</c>, <c>e-sidebar-body</c>, and <c>e-sidebar-footer</c>). The component renders no built-in toggle or close control; the consumer supplies those labels (see section 6.3).</para>
    /// </remarks>
    /// <example>
    /// The following example demonstrates how to declare and configure an <see cref="SfSidebar"/> component with header, body, footer, and target content regions:
    /// <code><![CDATA[
    /// <SfSidebar @bind-IsOpen="_open"
    ///            Mode="SidebarMode.Push"
    ///            Position="SidebarPosition.Start"
    ///            EnableMini="true"
    ///            Width="280px"
    ///            MiniWidth="64px">
    ///     <HeaderTemplate>
    ///         <div class="sidebar-brand">Application Menu</div>
    ///     </HeaderTemplate>
    ///     <ChildContent>
    ///         <nav>
    ///             <a href="/dashboard">Dashboard</a>
    ///             <a href="/settings">Settings</a>
    ///         </nav>
    ///     </ChildContent>
    ///     <FooterTemplate>
    ///         <div class="sidebar-footer">v1.0.0</div>
    ///     </FooterTemplate>
    ///     <TargetContent>
    ///         <main>
    ///             @Body
    ///         </main>
    ///     </TargetContent>
    /// </SfSidebar>
    ///
    /// @code {
    ///     private bool _open = true;
    /// }
    /// ]]></code>
    /// </example>
    public partial class SfSidebar : SfBaseComponent
    {
    }
}
```

---

## 2. Enumerations

### 2.1 `SidebarMode`

```csharp
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// Specifies the layout and display mode of the <see cref="SfSidebar"/> panel relative to the main content.
    /// </summary>
    /// <remarks>
    /// The <see cref="SidebarMode"/> enumeration determines how the sidebar interacts with the surrounding layout and <see cref="SfSidebar.TargetContent"/> when expanded or collapsed.
    /// When <see cref="SfSidebar.Responsive"/> is enabled and the viewport width falls below <see cref="SfSidebar.Breakpoint"/>, the sidebar automatically transitions to <see cref="SidebarMode.Overlay"/> behavior for mobile viewports.
    /// </remarks>
    /// <example>
    /// Configure the sidebar to push the main content when opened:
    /// <code><![CDATA[
    /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Push" Width="280px">
    ///     <ChildContent>Navigation Content</ChildContent>
    ///     <TargetContent>Main Page Content</TargetContent>
    /// </SfSidebar>
    /// ]]></code>
    /// </example>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SidebarMode
    {
        /// <summary>
        /// The sidebar panel slides over the main content without altering the layout width of the target content, optionally rendering a modal backdrop.
        /// </summary>
        /// <remarks>
        /// In <see cref="Overlay"/> mode, the root element receives the <c>e-sidebar-overlay</c> CSS class. When <see cref="SfSidebar.ShowBackdrop"/> is <c>true</c>, the panel acts as a modal dialog (<c>role="dialog"</c> and <c>aria-modal="true"</c>) and traps keyboard focus within the panel while open.
        /// </remarks>
        [EnumMember(Value = "Overlay")]
        Overlay,

        /// <summary>
        /// The sidebar panel pushes and translates the target content along the inline axis without changing the target content's width.
        /// </summary>
        /// <remarks>
        /// In <see cref="Push"/> mode, the root element receives the <c>e-sidebar-push</c> CSS class and shifts <see cref="SfSidebar.TargetContent"/> along the horizontal inline axis by the occupied panel width (<see cref="SfSidebar.Width"/> when open, or <see cref="SfSidebar.MiniWidth"/> when collapsed in mini mode).
        /// </remarks>
        [EnumMember(Value = "Push")]
        Push,

        /// <summary>
        /// The sidebar panel docks alongside the target content and reduces the available inline width of the target content container.
        /// </summary>
        /// <remarks>
        /// In <see cref="Shrink"/> mode, the root element receives the <c>e-sidebar-shrink</c> CSS class and dynamically resizes <see cref="SfSidebar.TargetContent"/> so both the sidebar and main content fit within the viewport without horizontal overflow.
        /// </remarks>
        [EnumMember(Value = "Shrink")]
        Shrink
    }
}
```

### 2.2 `SidebarPosition`

```csharp
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// Specifies the physical or flow-relative inline edge to which the <see cref="SfSidebar"/> panel is docked.
    /// </summary>
    /// <remarks>
    /// Use <see cref="Start"/> and <see cref="End"/> for internationalized layouts that automatically mirror between Left-to-Right (LTR) and Right-to-Left (RTL) document directions. Use <see cref="Left"/> and <see cref="Right"/> only when the sidebar must remain pinned to a fixed physical screen edge regardless of document direction.
    /// </remarks>
    /// <example>
    /// Dock the sidebar to the logical inline-end edge of the viewport:
    /// <code><![CDATA[
    /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Position="SidebarPosition.End"></SfSidebar>
    /// ]]></code>
    /// </example>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SidebarPosition
    {
        /// <summary>
        /// Docks the sidebar to the physical left edge of the container or viewport regardless of text direction.
        /// </summary>
        /// <remarks>
        /// Applies the <c>e-sidebar-left</c> CSS class in both Left-to-Right (LTR) and Right-to-Left (RTL) layouts.
        /// </remarks>
        [EnumMember(Value = "Left")]
        Left,

        /// <summary>
        /// Docks the sidebar to the physical right edge of the container or viewport regardless of text direction.
        /// </summary>
        /// <remarks>
        /// Applies the <c>e-sidebar-right</c> CSS class in both Left-to-Right (LTR) and Right-to-Left (RTL) layouts.
        /// </remarks>
        [EnumMember(Value = "Right")]
        Right,

        /// <summary>
        /// Docks the sidebar to the logical inline-start edge (physical left in LTR layouts; physical right in RTL layouts). This is the default position.
        /// </summary>
        /// <remarks>
        /// Resolves to <c>e-sidebar-left</c> when LTR is active and <c>e-sidebar-right</c> when RTL is active.
        /// </remarks>
        [EnumMember(Value = "Start")]
        Start,

        /// <summary>
        /// Docks the sidebar to the logical inline-end edge (physical right in LTR layouts; physical left in RTL layouts).
        /// </summary>
        /// <remarks>
        /// Resolves to <c>e-sidebar-right</c> when LTR is active and <c>e-sidebar-left</c> when RTL is active.
        /// </remarks>
        [EnumMember(Value = "End")]
        End
    }
}
```

### 2.3 `SidebarBreakpoint`

```csharp
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// Specifies the responsive viewport width threshold at which the <see cref="SfSidebar"/> transitions between mobile and desktop behaviors.
    /// </summary>
    /// <remarks>
    /// When <see cref="SfSidebar.Responsive"/> is set to <c>true</c>, viewports narrower than the selected <see cref="SidebarBreakpoint"/> trigger mobile behavior (typically collapsing the panel and switching to <see cref="SidebarMode.Overlay"/>), while viewports at or above the breakpoint use the configured persistent desktop <see cref="SfSidebar.Mode"/>.
    /// </remarks>
    /// <example>
    /// Set the sidebar responsive breakpoint to large screens (<c>992px</c>):
    /// <code><![CDATA[
    /// <SfSidebar @bind-IsOpen="IsSidebarOpen"
    ///            Responsive="true"
    ///            Breakpoint="SidebarBreakpoint.Lg"
    ///            Mode="SidebarMode.Shrink">
    /// </SfSidebar>
    /// ]]></code>
    /// </example>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SidebarBreakpoint
    {
        /// <summary>
        /// Disables breakpoint-based responsive adaptation regardless of viewport width.
        /// </summary>
        /// <remarks>
        /// When set to <see cref="None"/>, the sidebar maintains its configured <see cref="SfSidebar.Mode"/> across all screen sizes.
        /// </remarks>
        [EnumMember(Value = "None")]
        None,

        /// <summary>
        /// Extra-small viewport breakpoint with a minimum width of <c>0px</c>.
        /// </summary>
        /// <remarks>
        /// Desktop behavior applies at all viewport widths starting from <c>0px</c>.
        /// </remarks>
        [EnumMember(Value = "Xs")]
        Xs,

        /// <summary>
        /// Small viewport breakpoint with a typical minimum width of <c>576px</c>.
        /// </summary>
        /// <remarks>
        /// Viewports below <c>576px</c> adopt mobile overlay behavior; viewports at or above <c>576px</c> use persistent desktop mode.
        /// </remarks>
        [EnumMember(Value = "Sm")]
        Sm,

        /// <summary>
        /// Medium viewport breakpoint with a minimum width of <c>768px</c>. This is the default breakpoint.
        /// </summary>
        /// <remarks>
        /// The threshold is exactly <c>768px</c>, not a range. Viewports below <c>768px</c> adopt mobile overlay behavior; viewports at or above <c>768px</c> use the configured desktop mode. Provides standard tablet-to-desktop responsive switching when <see cref="SfSidebar.Responsive"/> is enabled.
        /// </remarks>
        [EnumMember(Value = "Md")]
        Md,

        /// <summary>
        /// Large viewport breakpoint with a typical minimum width of <c>992px</c>.
        /// </summary>
        /// <remarks>
        /// Viewports below <c>992px</c> adopt mobile overlay behavior; viewports at or above <c>992px</c> use persistent desktop mode.
        /// </remarks>
        [EnumMember(Value = "Lg")]
        Lg,

        /// <summary>
        /// Extra-large viewport breakpoint with a typical minimum width of <c>1200px</c>.
        /// </summary>
        /// <remarks>
        /// Viewports below <c>1200px</c> adopt mobile overlay behavior; viewports at or above <c>1200px</c> use persistent desktop mode.
        /// </remarks>
        [EnumMember(Value = "Xl")]
        Xl,

        /// <summary>
        /// Extra-extra-large viewport breakpoint with a typical minimum width of <c>1400px</c>.
        /// </summary>
        /// <remarks>
        /// Viewports below <c>1400px</c> adopt mobile overlay behavior; viewports at or above <c>1400px</c> use persistent desktop mode.
        /// </remarks>
        [EnumMember(Value = "Xxl")]
        Xxl,

        /// <summary>
        /// Always applies desktop behavior regardless of the current viewport width.
        /// </summary>
        /// <remarks>
        /// Prevents automatic fallback to mobile overlay mode on narrow viewports.
        /// </remarks>
        [EnumMember(Value = "Always")]
        Always
    }
}
```

---

## 3. Component Parameters (Properties)

```csharp
using Microsoft.AspNetCore.Components;

namespace Syncfusion.Blazor.Toolkit
{
    public partial class SfSidebar : SfBaseComponent
    {
        /// <summary>
        /// Gets or sets a value that indicates whether the sidebar panel is currently expanded (open).
        /// </summary>
        /// <value>
        /// <c>true</c> if the sidebar is expanded to its full <see cref="Width"/>; otherwise, <c>false</c>. The default value is <c>false</c>.
        /// </value>
        /// <remarks>
        /// When set to <c>true</c>, the root element receives the <c>e-sidebar-open</c> CSS class and expands to <see cref="Width"/>. When set to <c>false</c>, the sidebar either collapses completely or shrinks to <see cref="MiniWidth"/> if <see cref="EnableMini"/> is <c>true</c>. Supports two-way data binding via <c>@bind-IsOpen</c>.
        /// </remarks>
        /// <example>
        /// Bind the open state of the sidebar to a boolean field:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Width="280px">
        ///     <ChildContent>Navigation Items</ChildContent>
        /// </SfSidebar>
        /// @code {
        ///     private bool IsSidebarOpen = true;
        /// }
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool IsOpen { get; set; }

        /// <summary>
        /// Gets or sets the layout mode that determines how the sidebar interacts with the main page content.
        /// </summary>
        /// <value>
        /// One of the <see cref="SidebarMode"/> enumeration values (<see cref="SidebarMode.Overlay"/>, <see cref="SidebarMode.Push"/>, or <see cref="SidebarMode.Shrink"/>). The default value is <see cref="SidebarMode.Overlay"/>.
        /// </value>
        /// <remarks>
        /// In <see cref="SidebarMode.Overlay"/> mode, the panel floats above the page content with an optional backdrop. In <see cref="SidebarMode.Push"/> mode, the panel translates <see cref="TargetContent"/> along the inline axis. In <see cref="SidebarMode.Shrink"/> mode, the panel docks beside <see cref="TargetContent"/> and reduces its available width.
        /// </remarks>
        /// <example>
        /// Configure the sidebar to dock and shrink the target content:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Shrink">
        ///     <ChildContent>Sidebar Panel</ChildContent>
        ///     <TargetContent>Main View</TargetContent>
        /// </SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public SidebarMode Mode { get; set; } = SidebarMode.Overlay;

        /// <summary>
        /// Gets or sets the edge of the container or viewport where the sidebar panel is docked.
        /// </summary>
        /// <value>
        /// One of the <see cref="SidebarPosition"/> enumeration values. The default value is <see cref="SidebarPosition.Start"/>.
        /// </value>
        /// <remarks>
        /// When set to <see cref="SidebarPosition.Start"/> or <see cref="SidebarPosition.End"/>, the physical docking side automatically adapts to the document's Left-to-Right (LTR) or Right-to-Left (RTL) direction, applying <c>e-sidebar-left</c> or <c>e-sidebar-right</c> accordingly.
        /// </remarks>
        /// <example>
        /// Position the sidebar at the logical inline-start edge:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Position="SidebarPosition.Start"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public SidebarPosition Position { get; set; } = SidebarPosition.Start;

        /// <summary>
        /// Gets or sets the width of the sidebar panel when it is in the expanded (open) state.
        /// </summary>
        /// <value>
        /// A <c>string</c> representing a valid CSS length unit (such as <c>"280px"</c>, <c>"18rem"</c>, or <c>"25%"</c>). The default value is <c>"280px"</c>.
        /// </value>
        /// <remarks>
        /// This value defines the inline size of the panel when <see cref="IsOpen"/> is <c>true</c>, and determines the offset applied to <see cref="TargetContent"/> in <see cref="SidebarMode.Push"/> and <see cref="SidebarMode.Shrink"/> modes.
        /// </remarks>
        /// <example>
        /// Set a custom expanded width for the sidebar:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Width="320px"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public string Width { get; set; } = "280px";

        /// <summary>
        /// Gets or sets the width of the sidebar panel when collapsed into the mini-rail state.
        /// </summary>
        /// <value>
        /// A <c>string</c> representing a valid CSS length unit (such as <c>"64px"</c> or <c>"4rem"</c>). The default value is <c>"64px"</c>.
        /// </value>
        /// <remarks>
        /// This property takes effect only when <see cref="EnableMini"/> is set to <c>true</c> and <see cref="IsOpen"/> is <c>false</c>. It controls the compact rail width reserved for icons or compact navigation items.
        /// </remarks>
        /// <example>
        /// Enable the mini rail with a custom collapsed width of <c>72px</c>:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" EnableMini="true" MiniWidth="72px" Width="280px"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public string MiniWidth { get; set; } = "64px";

        /// <summary>
        /// Gets or sets a value that indicates whether the sidebar remains partially visible as a narrow mini rail when closed.
        /// </summary>
        /// <value>
        /// <c>true</c> to display a collapsed mini rail of width <see cref="MiniWidth"/> when <see cref="IsOpen"/> is <c>false</c>; <c>false</c> to hide the panel completely when closed. The default value is <c>false</c>.
        /// </value>
        /// <remarks>
        /// When <c>true</c> and <see cref="IsOpen"/> is <c>false</c>, the root element receives the <c>e-sidebar-mini</c> CSS class and remains in the accessibility tree so interactive icon buttons within the rail remain keyboard-focusable.
        /// </remarks>
        /// <example>
        /// Configure the sidebar to collapse into a mini icon rail when closed:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Push" EnableMini="true" MiniWidth="64px"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool EnableMini { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether hovering the pointer over the collapsed mini rail temporarily expands the sidebar on desktop viewports.
        /// </summary>
        /// <value>
        /// <c>true</c> to expand the mini sidebar on pointer hover; otherwise, <c>false</c>. The default value is <c>false</c>.
        /// </value>
        /// <remarks>
        /// This setting applies only when <see cref="EnableMini"/> is <c>true</c> and the sidebar is currently collapsed (<see cref="IsOpen"/> is <c>false</c>) on a desktop viewport. Moving the pointer away collapses the panel back to <see cref="MiniWidth"/> unless explicitly opened.
        /// </remarks>
        /// <example>
        /// Enable automatic expansion when hovering over the mini rail:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" EnableMini="true" OpenMiniOnHover="true"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool OpenMiniOnHover { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the sidebar automatically adapts its mode and open state based on the viewport breakpoint.
        /// </summary>
        /// <value>
        /// <c>true</c> to enable breakpoint-driven responsive behavior; otherwise, <c>false</c>. The default value is <c>true</c>.
        /// </value>
        /// <remarks>
        /// When set to <c>true</c>, the component monitors the viewport width relative to <see cref="Breakpoint"/>. Below the breakpoint, the sidebar switches to mobile behavior (<see cref="SidebarMode.Overlay"/>) and invokes <see cref="OnBreakpointChanged"/>. When <c>false</c>, the configured <see cref="Mode"/> is used at all viewport sizes.
        /// </remarks>
        /// <example>
        /// Enable responsive mode switching at the medium breakpoint:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Responsive="true" Breakpoint="SidebarBreakpoint.Md" Mode="SidebarMode.Push"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool Responsive { get; set; } = true;

        /// <summary>
        /// Gets or sets the viewport width breakpoint below which the sidebar switches to mobile overlay behavior.
        /// </summary>
        /// <value>
        /// One of the <see cref="SidebarBreakpoint"/> enumeration values. The default value is <see cref="SidebarBreakpoint.Md"/>.
        /// </value>
        /// <remarks>
        /// Used in conjunction with <see cref="Responsive"/>. When the viewport width is below the specified <see cref="SidebarBreakpoint"/>, the effective mode becomes <see cref="SidebarMode.Overlay"/>; at or above the breakpoint, the sidebar uses the configured <see cref="Mode"/>.
        /// </remarks>
        /// <example>
        /// Configure the sidebar to switch to mobile mode below the large (<c>Lg</c>) breakpoint:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Responsive="true" Breakpoint="SidebarBreakpoint.Lg"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public SidebarBreakpoint Breakpoint { get; set; } = SidebarBreakpoint.Md;

        /// <summary>
        /// Gets or sets a value that indicates whether clicking the backdrop overlay closes the sidebar when in <see cref="SidebarMode.Overlay"/> mode.
        /// </summary>
        /// <value>
        /// <c>true</c> to close the sidebar when the user clicks the backdrop; otherwise, <c>false</c>. The default value is <c>true</c>.
        /// </value>
        /// <remarks>
        /// This property applies only when the effective mode is <see cref="SidebarMode.Overlay"/> and <see cref="ShowBackdrop"/> is <c>true</c>. If <see cref="IsEnabled"/> is <c>false</c>, backdrop clicks are ignored.
        /// </remarks>
        /// <example>
        /// Prevent the overlay sidebar from closing when the user clicks outside on the backdrop:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Overlay" CloseOnOverlayClick="false"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool CloseOnOverlayClick { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that indicates whether pressing the <c>Escape</c> key closes the sidebar when focus is within scope.
        /// </summary>
        /// <value>
        /// <c>true</c> to close the sidebar when the <c>Escape</c> key is pressed; otherwise, <c>false</c>. The default value is <c>true</c>.
        /// </value>
        /// <remarks>
        /// When closed via the <c>Escape</c> key in <see cref="SidebarMode.Overlay"/> mode, keyboard focus is automatically restored to the element that triggered the sidebar prior to opening.
        /// </remarks>
        /// <example>
        /// Enable closing the sidebar with the Escape key:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" CloseOnEscape="true"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool CloseOnEscape { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that indicates whether the sidebar automatically closes when a navigation location change occurs via <see cref="NavigationManager"/>.
        /// </summary>
        /// <value>
        /// <c>true</c> to close the sidebar automatically upon route navigation; otherwise, <c>false</c>. The default value is <c>true</c>.
        /// </value>
        /// <remarks>
        /// The component subscribes only when <see cref="IsOpenChanged"/> has a delegate (two-way binding), and removes the subscription on disposal (Spec O3). <c>CloseOnNavigate="false"</c> never subscribes. This behavior is particularly useful in <see cref="SidebarMode.Overlay"/> or mobile viewports where selecting a navigation link inside the sidebar should dismiss the drawer and reveal the newly navigated page.
        /// </remarks>
        /// <example>
        /// Keep the sidebar open across route changes by setting <see cref="CloseOnNavigate"/> to <c>false</c>:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" CloseOnNavigate="false"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool CloseOnNavigate { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that indicates whether a dimming backdrop element is rendered behind the sidebar in <see cref="SidebarMode.Overlay"/> mode.
        /// </summary>
        /// <value>
        /// <c>true</c> to render the backdrop element in <see cref="SidebarMode.Overlay"/> mode; otherwise, <c>false</c>. The default value is <c>true</c>.
        /// </value>
        /// <remarks>
        /// When <c>true</c> and the effective mode is <see cref="SidebarMode.Overlay"/>, an <c>e-sidebar-backdrop</c> element with <c>aria-hidden="true"</c> is rendered over the page content, and the sidebar panel operates as a modal dialog (<c>role="dialog"</c>, <c>aria-modal="true"</c>).
        /// </remarks>
        /// <example>
        /// Render an overlay sidebar with a visible modal backdrop:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Overlay" ShowBackdrop="true"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool ShowBackdrop { get; set; } = true;

        /// <summary>
        /// Gets or sets one or more custom CSS class names to append to the backdrop element.
        /// </summary>
        /// <value>
        /// A space-separated <c>string</c> of CSS classes applied to the <c>e-sidebar-backdrop</c> element, or <c>null</c> if no custom classes are specified. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// Use this property to customize the backdrop opacity, blur filter, or background color when <see cref="ShowBackdrop"/> is enabled in <see cref="SidebarMode.Overlay"/> mode.
        /// </remarks>
        /// <example>
        /// Apply a custom CSS class to style the sidebar backdrop:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Overlay" BackdropClass="custom-frosted-backdrop"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public string? BackdropClass { get; set; }

        /// <summary>
        /// Gets or sets the duration of the open and close transition animation in milliseconds.
        /// </summary>
        /// <value>
        /// An <c>int</c> specifying the transition duration in milliseconds. The default value is <c>300</c>.
        /// </value>
        /// <remarks>
        /// This value controls the CSS transition duration when expanding or collapsing the sidebar. If <see cref="EnableAnimation"/> is <c>false</c> or the user's operating system/browser reports <c>prefers-reduced-motion: reduce</c>, transitions complete instantaneously regardless of this setting.
        /// </remarks>
        /// <example>
        /// Set the sidebar open and close animation duration to 200 milliseconds:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Duration="200" EnableAnimation="true"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public int Duration { get; set; } = 300;

        /// <summary>
        /// Gets or sets a value that indicates whether smooth CSS transitions are enabled when opening, closing, or resizing the sidebar.
        /// </summary>
        /// <value>
        /// <c>true</c> to enable open and close animations; otherwise, <c>false</c>. The default value is <c>true</c>.
        /// </value>
        /// <remarks>
        /// When set to <c>false</c>, state changes between open, closed, and mini modes occur immediately without transition delay. Also respects the global animation configuration and <c>prefers-reduced-motion</c> media query.
        /// </remarks>
        /// <example>
        /// Disable transition animations on the sidebar:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" EnableAnimation="false"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool EnableAnimation { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that indicates whether the sidebar uses viewport-fixed positioning (<c>position: fixed</c>) or container-relative positioning (<c>position: absolute</c>).
        /// </summary>
        /// <value>
        /// <c>true</c> to position the sidebar fixed relative to the viewport; <c>false</c> to position it relative to its parent container. The default value is <c>true</c>.
        /// </value>
        /// <remarks>
        /// Set this property to <c>false</c> when embedding the <see cref="SfSidebar"/> inside a scoped inner container or panel rather than anchoring it to the full browser viewport.
        /// </remarks>
        /// <example>
        /// Embed the sidebar within a relative parent container:
        /// <code><![CDATA[
        /// <div style="position: relative; height: 500px; overflow: hidden;">
        ///     <SfSidebar @bind-IsOpen="IsSidebarOpen" Fixed="false"></SfSidebar>
        /// </div>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool Fixed { get; set; } = true;

        /// <summary>
        /// Gets or sets one or more custom CSS class names to append to the panel element (<c>div.e-sidebar</c>) of the sidebar component.
        /// </summary>
        /// <value>
        /// A space-separated <c>string</c> of custom CSS class names, or <c>null</c>. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// Custom classes specified here are appended alongside the built-in <c>e-sidebar</c> root class, allowing targeted theme overrides or custom styling.
        /// </remarks>
        /// <example>
        /// Add a custom CSS class to the sidebar root element:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" CssClass="app-primary-sidebar"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public string? CssClass { get; set; }

        /// <summary>
        /// Gets or sets the unique HTML <c>id</c> attribute applied to the panel element (<c>div.e-sidebar</c>) of the sidebar.
        /// </summary>
        /// <value>
        /// A <c>string</c> representing the element identifier. If <c>null</c> or omitted, a unique identifier is automatically generated.
        /// </value>
        /// <remarks>
        /// Specifying a deterministic <see cref="Id"/> is recommended so external toggle buttons can reference the sidebar via <c>aria-controls</c> and automated tests or styles can target the panel reliably. The layout host (<c>div.e-sidebar-container</c>) never receives the identifier.
        /// </remarks>
        /// <example>
        /// Associate a toggle button with the sidebar using a custom <see cref="Id"/>:
        /// <code><![CDATA[
        /// <button aria-expanded="@IsSidebarOpen" aria-controls="main-nav-sidebar" @onclick="() => IsSidebarOpen = !IsSidebarOpen">
        ///     Menu
        /// </button>
        /// <SfSidebar Id="main-nav-sidebar" @bind-IsOpen="IsSidebarOpen"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the accessible name (<c>aria-label</c>) for the sidebar panel when no visible header element is present.
        /// </summary>
        /// <value>
        /// A <c>string</c> announced by assistive technologies as the accessible label of the sidebar region or dialog, or <c>null</c>. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// When the sidebar is rendered as a modal <c>dialog</c> or landmark region (<c>complementary</c> / <c>navigation</c>) without a visible heading, provide <see cref="AriaLabel"/> to satisfy WCAG 4.1.2 Name, Role, Value requirements. If <see cref="AriaLabelledBy"/> is also specified, <c>aria-labelledby</c> takes precedence per WAI-ARIA specifications.
        /// </remarks>
        /// <example>
        /// Provide an accessible label for a navigation sidebar:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" AriaLabel="Primary navigation"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public string? AriaLabel { get; set; }

        /// <summary>
        /// Gets or sets the HTML <c>id</c> of an existing DOM element that provides the accessible name (<c>aria-labelledby</c>) for the sidebar panel.
        /// </summary>
        /// <value>
        /// A <c>string</c> containing one or more space-separated element IDs that label the sidebar, or <c>null</c>. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// Use this property when a visible heading exists inside <see cref="HeaderTemplate"/> or elsewhere on the page so screen readers announce that heading as the sidebar's accessible name.
        /// </remarks>
        /// <example>
        /// Reference a heading inside <see cref="HeaderTemplate"/> using <see cref="AriaLabelledBy"/>:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" AriaLabelledBy="sidebar-title">
        ///     <HeaderTemplate>
        ///         <h2 id="sidebar-title">Workspace Navigation</h2>
        ///     </HeaderTemplate>
        /// </SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public string? AriaLabelledBy { get; set; }

        /// <summary>
        /// Gets or sets the explicit WAI-ARIA <c>role</c> attribute for the sidebar panel, overriding the automatically resolved role.
        /// </summary>
        /// <value>
        /// A <c>string</c> specifying the ARIA role (such as <c>"dialog"</c>, <c>"navigation"</c>, or <c>"complementary"</c>), or <c>null</c> to resolve the role automatically based on the active mode. The default value is <c>null</c> (auto-resolved).
        /// </value>
        /// <remarks>
        /// When <c>null</c>, the component deterministically resolves the ARIA role according to the effective mode:
        /// <list type="bullet">
        /// <item><description>In <see cref="SidebarMode.Overlay"/> mode when <see cref="ShowBackdrop"/> is <c>true</c>, the panel receives <c>role="dialog"</c> and <c>aria-modal="true"</c>.</description></item>
        /// <item><description>In <see cref="SidebarMode.Push"/> or <see cref="SidebarMode.Shrink"/> mode (or non-modal <see cref="SidebarMode.Overlay"/>), the panel defaults to <c>role="navigation"</c> (or <c>role="complementary"</c> when overridden for secondary tool panels).</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// Explicitly set the ARIA role of a secondary tools sidebar to <c>complementary</c>:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Shrink" Role="complementary" AriaLabel="Inspector panel"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public string? Role { get; set; }

        /// <summary>
        /// Gets or sets a collection of additional HTML attributes to be applied to the panel element (<c>div.e-sidebar</c>) of the sidebar component.
        /// </summary>
        /// <value>
        /// A <see cref="Dictionary{TKey, TValue}"/> of attribute names and values splatted onto the root element, or <c>null</c>. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// Use this property to pass custom <c>data-*</c> attributes, test identifiers (such as <c>data-testid</c>), or additional ARIA attributes to the underlying host element.
        /// </remarks>
        /// <example>
        /// Pass custom HTML attributes to the sidebar root element:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" HtmlAttributes="@SidebarAttributes"></SfSidebar>
        /// @code {
        ///     private Dictionary<string, object> SidebarAttributes = new()
        ///     {
        ///         { "data-testid", "app-sidebar" }
        ///     };
        /// }
        /// ]]></code>
        /// </example>
        [Parameter]
        public Dictionary<string, object>? HtmlAttributes { get; set; }

        /// <summary>
        /// Gets or sets the main body content rendered inside the <c>e-sidebar-body</c> region of the sidebar panel.
        /// </summary>
        /// <value>
        /// A <see cref="RenderFragment"/> containing the primary markup of the sidebar panel, or <c>null</c>. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// The body region sits between <see cref="HeaderTemplate"/> and <see cref="FooterTemplate"/> and scrolls independently when its content exceeds the available panel height.
        /// </remarks>
        /// <example>
        /// Populate the main body of the sidebar with navigation links:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen">
        ///     <ChildContent>
        ///         <ul class="nav-list">
        ///             <li><a href="/">Home</a></li>
        ///             <li><a href="/reports">Reports</a></li>
        ///         </ul>
        ///     </ChildContent>
        /// </SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the optional template rendered at the top (<c>e-sidebar-header</c> region) of the sidebar panel.
        /// </summary>
        /// <value>
        /// A <see cref="RenderFragment"/> defining the header content (such as branding, title, or a close button), or <c>null</c> if no header region is required. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// When <c>null</c>, the <c>e-sidebar-header</c> container is omitted from the rendered DOM. When provided, it remains pinned at the top of the panel above the scrollable <see cref="ChildContent"/> body.
        /// </remarks>
        /// <example>
        /// Render a brand header and close button inside the sidebar header region:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen">
        ///     <HeaderTemplate>
        ///         <div class="d-flex justify-content-between align-items-center">
        ///             <span>Syncfusion Portal</span>
        ///             <button type="button" @onclick="() => IsSidebarOpen = false">Close</button>
        ///         </div>
        ///     </HeaderTemplate>
        /// </SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public RenderFragment? HeaderTemplate { get; set; }

        /// <summary>
        /// Gets or sets the optional template rendered at the bottom (<c>e-sidebar-footer</c> region) of the sidebar panel.
        /// </summary>
        /// <value>
        /// A <see cref="RenderFragment"/> defining the footer content (such as user profile controls, settings links, or version info), or <c>null</c> if no footer region is required. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// When <c>null</c>, the <c>e-sidebar-footer</c> container is omitted from the rendered DOM. When provided, it remains pinned at the bottom of the panel below the scrollable <see cref="ChildContent"/> body.
        /// </remarks>
        /// <example>
        /// Render user profile information in the sidebar footer:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen">
        ///     <ChildContent>Menu Items</ChildContent>
        ///     <FooterTemplate>
        ///         <div class="user-summary">Signed in as Admin</div>
        ///     </FooterTemplate>
        /// </SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public RenderFragment? FooterTemplate { get; set; }

        /// <summary>
        /// Gets or sets the main application or page content that is positioned alongside the sidebar and automatically translated or resized in <see cref="SidebarMode.Push"/> and <see cref="SidebarMode.Shrink"/> modes.
        /// </summary>
        /// <value>
        /// A <see cref="RenderFragment"/> representing the primary page layout content, or <c>null</c> when using the sidebar in standalone mode. The default value is <c>null</c>.
        /// </value>
        /// <remarks>
        /// Providing <see cref="TargetContent"/> enables integrated layout management where the component automatically shifts or resizes the main view based on <see cref="Mode"/>, <see cref="Position"/>, <see cref="Width"/>, and <see cref="MiniWidth"/>. If omitted (<c>null</c>), the sidebar renders as a standalone panel.
        /// </remarks>
        /// <example>
        /// Wrap the main page body inside <see cref="TargetContent"/> for automatic layout adjustment:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Shrink" Width="260px">
        ///     <ChildContent>Sidebar Navigation</ChildContent>
        ///     <TargetContent>
        ///         <article class="main-content">
        ///             <h1>Dashboard Overview</h1>
        ///         </article>
        ///     </TargetContent>
        /// </SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public RenderFragment? TargetContent { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether interactive user actions (such as backdrop clicks, Escape key presses, or hover expansion) are enabled on the sidebar.
        /// </summary>
        /// <value>
        /// <c>true</c> if user-initiated open and close interactions are enabled; otherwise, <c>false</c>. The default value is <c>true</c>.
        /// </value>
        /// <remarks>
        /// When set to <c>false</c>, the sidebar continues to display its current visual state (<see cref="IsOpen"/>), but ignores user-driven open and close interactions including backdrop clicks, <c>Escape</c> key dismissal, and mini-rail hover expansion.
        /// </remarks>
        /// <example>
        /// Lock the sidebar in its current state by disabling user interaction:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" IsEnabled="false"></SfSidebar>
        /// ]]></code>
        /// </example>
        [Parameter]
        public bool IsEnabled { get; set; } = true;
    }
}
```

---

## 4. Events & Event Arguments

### 4.1 Event Callbacks

```csharp
using Microsoft.AspNetCore.Components;

namespace Syncfusion.Blazor.Toolkit
{
    public partial class SfSidebar : SfBaseComponent
    {
        /// <summary>
        /// Gets or sets an event callback that is invoked when the <see cref="IsOpen"/> property changes, supporting two-way data binding (<c>@bind-IsOpen</c>).
        /// </summary>
        /// <value>
        /// An <see cref="EventCallback{TValue}"/> of type <see cref="bool"/> that receives the updated open state (<c>true</c> when opened; <c>false</c> when closed).
        /// </value>
        /// <remarks>
        /// This callback is raised whenever the sidebar's open state changes due to user interaction (backdrop click, <c>Escape</c> key, navigation change), responsive breakpoint transitions, or programmatic calls to <see cref="OpenAsync"/>, <see cref="CloseAsync"/>, or <see cref="ToggleAsync"/>.
        /// </remarks>
        /// <example>
        /// Handle changes to the open state manually or via two-way binding:
        /// <code><![CDATA[
        /// <SfSidebar IsOpen="@IsSidebarOpen" IsOpenChanged="@OnSidebarOpenChanged"></SfSidebar>
        /// @code {
        ///     private bool IsSidebarOpen;
        ///     private void OnSidebarOpenChanged(bool isOpen)
        ///     {
        ///         IsSidebarOpen = isOpen;
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }

        /// <summary>
        /// Gets or sets an event callback that is invoked after the sidebar has opened and any open transition animation has completed.
        /// </summary>
        /// <value>
        /// An <see cref="EventCallback{TValue}"/> of type <see cref="SidebarEventArgs"/> providing the resulting open state and active <see cref="SidebarMode"/>.
        /// </value>
        /// <remarks>
        /// Use this event to perform post-open operations, such as refreshing child components inside the panel or logging analytics after the sidebar is fully expanded.
        /// </remarks>
        /// <example>
        /// Subscribe to the <see cref="OnOpened"/> event:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" OnOpened="@HandleOpened"></SfSidebar>
        /// @code {
        ///     private bool IsSidebarOpen;
        ///     private void HandleOpened(SidebarEventArgs args)
        ///     {
        ///         Console.WriteLine($"Sidebar opened in {args.Mode} mode.");
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        [Parameter]
        public EventCallback<SidebarEventArgs> OnOpened { get; set; }

        /// <summary>
        /// Gets or sets an event callback that is invoked after the sidebar has closed or collapsed and any close transition animation has completed.
        /// </summary>
        /// <value>
        /// An <see cref="EventCallback{TValue}"/> of type <see cref="SidebarEventArgs"/> providing the resulting closed state and active <see cref="SidebarMode"/>.
        /// </value>
        /// <remarks>
        /// Use this event to execute cleanup logic or update surrounding layout state once the sidebar has finished collapsing to hidden or mini-rail state.
        /// </remarks>
        /// <example>
        /// Subscribe to the <see cref="OnClosed"/> event:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen" OnClosed="@HandleClosed"></SfSidebar>
        /// @code {
        ///     private bool IsSidebarOpen = true;
        ///     private void HandleClosed(SidebarEventArgs args)
        ///     {
        ///         Console.WriteLine($"Sidebar closed. IsOpen={args.IsOpen}, Mode={args.Mode}");
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        [Parameter]
        public EventCallback<SidebarEventArgs> OnClosed { get; set; }

        /// <summary>
        /// Gets or sets an event callback that is invoked when the viewport crosses the configured <see cref="Breakpoint"/> threshold while <see cref="Responsive"/> is enabled.
        /// </summary>
        /// <value>
        /// An <see cref="EventCallback{TValue}"/> of type <see cref="bool"/> that receives <c>true</c> when the viewport width falls below <see cref="Breakpoint"/> (entering mobile behavior) and <c>false</c> when the viewport width is at or above <see cref="Breakpoint"/> (entering desktop behavior).
        /// </value>
        /// <remarks>
        /// Use this callback to synchronize header toggle button visibility or adjust application layout state when transitioning between mobile and desktop viewports.
        /// </remarks>
        /// <example>
        /// Track whether the sidebar is operating below the responsive breakpoint:
        /// <code><![CDATA[
        /// <SfSidebar @bind-IsOpen="IsSidebarOpen"
        ///            Responsive="true"
        ///            Breakpoint="SidebarBreakpoint.Md"
        ///            OnBreakpointChanged="@HandleBreakpointChanged">
        /// </SfSidebar>
        /// @code {
        ///     private bool IsSidebarOpen = true;
        ///     private bool IsMobileViewport;
        ///     private void HandleBreakpointChanged(bool isBelowBreakpoint)
        ///     {
        ///         IsMobileViewport = isBelowBreakpoint;
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        [Parameter]
        public EventCallback<bool> OnBreakpointChanged { get; set; }
    }
}
```

### 4.2 `SidebarEventArgs`

```csharp
using System;

namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// Provides event data for the <see cref="SfSidebar.OnOpened"/> and <see cref="SfSidebar.OnClosed"/> events.
    /// </summary>
    /// <remarks>
    /// An instance of <see cref="SidebarEventArgs"/> is passed to event handlers when the <see cref="SfSidebar"/> finishes expanding or collapsing, exposing both the resulting open state and the effective <see cref="SidebarMode"/> active at the time of the transition.
    /// </remarks>
    /// <example>
    /// Inspect the properties of <see cref="SidebarEventArgs"/> in an event handler:
    /// <code><![CDATA[
    /// <SfSidebar @bind-IsOpen="IsSidebarOpen" OnOpened="OnSidebarStateChanged" OnClosed="OnSidebarStateChanged"></SfSidebar>
    /// @code {
    ///     private bool IsSidebarOpen;
    ///     private void OnSidebarStateChanged(SidebarEventArgs args)
    ///     {
    ///         Console.WriteLine($"IsOpen: {args.IsOpen}, Effective Mode: {args.Mode}");
    ///     }
    /// }
    /// ]]></code>
    /// </example>
    public sealed class SidebarEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating the resulting open state of the sidebar after the transition completes.
        /// </summary>
        /// <value>
        /// <c>true</c> if the sidebar is now open/expanded; <c>false</c> if the sidebar is now closed or collapsed to its mini rail.
        /// </value>
        /// <remarks>
        /// For <see cref="SfSidebar.OnOpened"/>, this property is <c>true</c>. For <see cref="SfSidebar.OnClosed"/>, this property is <c>false</c>.
        /// </remarks>
        /// <example>
        /// Check the resulting state in an event callback:
        /// <code><![CDATA[
        /// private void HandleSidebarEvent(SidebarEventArgs args)
        /// {
        ///     if (args.IsOpen)
        ///     {
        ///         // Sidebar is expanded
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        public required bool IsOpen { get; init; }

        /// <summary>
        /// Gets or sets the effective <see cref="SidebarMode"/> active when the open or close transition occurred.
        /// </summary>
        /// <value>
        /// A <see cref="SidebarMode"/> value (<see cref="SidebarMode.Overlay"/>, <see cref="SidebarMode.Push"/>, or <see cref="SidebarMode.Shrink"/>) representing the active layout mode.
        /// </value>
        /// <remarks>
        /// When <see cref="SfSidebar.Responsive"/> is enabled and the viewport is below <see cref="SfSidebar.Breakpoint"/>, this property reflects the effective responsive mode (<see cref="SidebarMode.Overlay"/>) rather than the static <see cref="SfSidebar.Mode"/> parameter.
        /// </remarks>
        /// <example>
        /// Determine if the sidebar opened as a modal overlay:
        /// <code><![CDATA[
        /// private void HandleOpened(SidebarEventArgs args)
        /// {
        ///     bool isOverlay = args.Mode == SidebarMode.Overlay;
        /// }
        /// ]]></code>
        /// </example>
        public SidebarMode Mode { get; init; }

        // Compatibility members that predate this contract and are retained (see section 4.3):
        //   public required SidebarTrigger Trigger { get; init; }
    }
}
```

---

### 4.3 Compatibility decisions

| Member | Decision |
|--------|----------|
| `SidebarEventArgs` is `sealed`, with `init` accessors and a `required` `IsOpen` | The shipped shape is kept so existing handlers and object initializers compile. `Mode` is added as `init`. |
| `SidebarEventArgs.Trigger` (`SidebarTrigger`) | Retained for compatibility. It is outside the v1 contract and does not appear in `API.md`. |
| `SfSidebar.MediaQuery`, `SfSidebar.EnableGestures`, `SidebarTrigger` | Retained legacy members. They add no behavior beyond their shipped documentation. |
| `SidebarMode` / `SidebarPosition` numeric values | The shipped zero values (`Overlay`, `Start`) are kept. Declaration order in this file is documentation order only. |
| `Width` / `MiniWidth` are `string?` | The shipped nullable annotation is kept. `null` or an unsafe value falls back to the default. |

---

## 5. Public Instance Methods

```csharp
using System.Threading.Tasks;

namespace Syncfusion.Blazor.Toolkit
{
    public partial class SfSidebar : SfBaseComponent
    {
        /// <summary>
        /// Asynchronously opens and expands the sidebar panel to its full <see cref="Width"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous open operation.
        /// </returns>
        /// <remarks>
        /// Calling <see cref="OpenAsync"/> when the sidebar is already open (<see cref="IsOpen"/> is <c>true</c>) completes as a no-op. <see cref="IsEnabled"/> does not gate this method (Spec O2). When the state changes, <see cref="IsOpenChanged"/> is invoked, and <see cref="OnOpened"/> follows once the animation has completed.
        /// </remarks>
        /// <example>
        /// Open the sidebar programmatically using a component reference (<c>@ref</c>):
        /// <code><![CDATA[
        /// <button @onclick="OpenSidebarAsync">Open Sidebar</button>
        /// <SfSidebar @ref="SidebarRef" Width="280px"></SfSidebar>
        /// @code {
        ///     private SfSidebar? SidebarRef;
        ///     private async Task OpenSidebarAsync()
        ///     {
        ///         if (SidebarRef is not null)
        ///         {
        ///             await SidebarRef.OpenAsync();
        ///         }
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        public async Task OpenAsync()
        {
            // Implementation
        }

        /// <summary>
        /// Asynchronously closes or collapses the sidebar panel (either hiding it completely or collapsing it to <see cref="MiniWidth"/> when <see cref="EnableMini"/> is <c>true</c>).
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous close operation.
        /// </returns>
        /// <remarks>
        /// Calling <see cref="CloseAsync"/> when the sidebar is already closed (<see cref="IsOpen"/> is <c>false</c>) completes as a no-op. <see cref="IsEnabled"/> does not gate this method (Spec O2). In <see cref="SidebarMode.Overlay"/> mode, closing the panel restores keyboard focus to the opener element and invokes <see cref="IsOpenChanged"/> and then <see cref="OnClosed"/>.
        /// </remarks>
        /// <example>
        /// Close the sidebar programmatically using a component reference (<c>@ref</c>):
        /// <code><![CDATA[
        /// <button @onclick="CloseSidebarAsync">Close Sidebar</button>
        /// <SfSidebar @ref="SidebarRef" @bind-IsOpen="IsSidebarOpen"></SfSidebar>
        /// @code {
        ///     private SfSidebar? SidebarRef;
        ///     private bool IsSidebarOpen = true;
        ///     private async Task CloseSidebarAsync()
        ///     {
        ///         if (SidebarRef is not null)
        ///         {
        ///             await SidebarRef.CloseAsync();
        ///         }
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        public async Task CloseAsync()
        {
            // Implementation
        }

        /// <summary>
        /// Asynchronously toggles the sidebar panel between its open (expanded) and closed (collapsed or mini) states.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous toggle operation.
        /// </returns>
        /// <remarks>
        /// If <see cref="IsOpen"/> is currently <c>false</c>, this method invokes <see cref="OpenAsync"/>; if <see cref="IsOpen"/> is <c>true</c>, it invokes <see cref="CloseAsync"/>. <see cref="IsEnabled"/> does not gate this method (Spec O2).
        /// </remarks>
        /// <example>
        /// Toggle the sidebar state from a toolbar button using <c>@ref</c>:
        /// <code><![CDATA[
        /// <button @onclick="ToggleSidebarAsync">Toggle Menu</button>
        /// <SfSidebar @ref="SidebarRef" Mode="SidebarMode.Push"></SfSidebar>
        /// @code {
        ///     private SfSidebar? SidebarRef;
        ///     private async Task ToggleSidebarAsync()
        ///     {
        ///         if (SidebarRef is not null)
        ///         {
        ///             await SidebarRef.ToggleAsync();
        ///         }
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        public async Task ToggleAsync()
        {
            // Implementation
        }

        /// <summary>
        /// Asynchronously moves keyboard focus into the sidebar panel.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous focus operation.
        /// </returns>
        /// <remarks>
        /// Focuses the first focusable interactive element inside the sidebar panel, or the panel container itself if no focusable child element exists. Primarily used in <see cref="SidebarMode.Overlay"/> mode or custom keyboard navigation workflows. Completes without throwing when the panel is not focusable.
        /// </remarks>
        /// <example>
        /// Programmatically move focus into the sidebar panel:
        /// <code><![CDATA[
        /// <SfSidebar @ref="SidebarRef" @bind-IsOpen="IsSidebarOpen" Mode="SidebarMode.Overlay"></SfSidebar>
        /// @code {
        ///     private SfSidebar? SidebarRef;
        ///     private bool IsSidebarOpen = true;
        ///     private async Task FocusSidebarAsync()
        ///     {
        ///         if (SidebarRef is not null)
        ///         {
        ///             await SidebarRef.FocusAsync();
        ///         }
        ///     }
        /// }
        /// ]]></code>
        /// </example>
        public async Task FocusAsync()
        {
            // Implementation
        }
    }
}
```

---

## 6. Public CSS Classes, Accessibility & Localization Reference

### 6.1 Public CSS Class Hooks

| CSS Class | Applied When |
|-----------|--------------|
| `e-sidebar` | Always applied to the panel (`div`) element. |
| `e-sidebar-open` | Applied when the sidebar is open/expanded (`IsOpen == true`). |
| `e-sidebar-mini` | Applied when the collapsed mini rail is visible (`IsOpen == false` and `EnableMini == true`). |
| `e-sidebar-overlay` | Applied when the effective mode is `SidebarMode.Overlay`. |
| `e-sidebar-push` | Applied when the effective mode is `SidebarMode.Push`. |
| `e-sidebar-shrink` | Applied when the effective mode is `SidebarMode.Shrink`. |
| `e-sidebar-left` / `e-sidebar-right` | Applied according to the resolved physical side (`Left`, `Right`, or resolved `Start`/`End` under LTR/RTL). |
| `e-sidebar-backdrop` | Applied to the modal backdrop element when the backdrop rule in Spec M-O2 applies. `BackdropClass` is appended to this element. |
| `e-sidebar-header` / `e-sidebar-body` / `e-sidebar-footer` | Applied to the header (`HeaderTemplate`), body (`ChildContent`), and footer (`FooterTemplate`) regions. |

> **CSS Isolation Note:** Classes are applied to scoped elements; use `::deep` in consumer stylesheets when overriding internal region styles.

### 6.2 Accessibility Contract Summary

| Context | Resolved ARIA Role & Attributes |
|---------|---------------------------------|
| **Overlay + Modal (`ShowBackdrop == true`)** | `role="dialog"`, `aria-modal="true"`, accessible name via `AriaLabelledBy` (preferred) or `AriaLabel`. |
| **Push / Shrink** | `role="navigation"` (default) or `role="complementary"` (via `Role`), `aria-hidden="true"` when fully closed without mini rail. |
| **Mini Closed (`EnableMini == true`, `IsOpen == false`)** | `aria-hidden="false"`; panel remains in the accessibility tree so interactive icons remain focusable. |
| **Backdrop Element** | `aria-hidden="true"` (decorative). |
| **Consumer Toggle Button** | `aria-expanded="{IsOpen}"`, `aria-controls="{Id}"` pointing to the sidebar's `Id`. |

### 6.3 Localization

v1 has no built-in chrome strings and ships no `Sidebar_Close` or `Sidebar_Open` resource keys (`API.md`, Localization). The consumer supplies the toggle label, `AriaLabel`, and `AriaLabelledBy`. The earlier `SidebarResourceKeys` listing is withdrawn. The shipped component keeps its existing `Sidebar_Label`, `Sidebar_Opened`, and `Sidebar_Closed` strings (default accessible name and live-region announcement); they are not new v1 surface.
