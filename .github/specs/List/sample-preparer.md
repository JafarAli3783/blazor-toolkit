# Sample Implementation Plan – SfList
## Syncfusion Blazor Toolkit

**Status:** Proposed. No sample is implemented.  
**Host, when implementation starts:** `samples/Blazor.Toolkit.Samples`  
**Authority:** Every API name comes from `API.md`. Every cited test ID exists in `TEST-MATRIX.md`. Sorting, drag-and-drop, and component-owned persistence are not sample features.

---

## Sample 01 – Employee directory

**Story:** US-02, US-04  
**Scenario:** Pick one employee for a detail panel.  
**APIs:** DataSource, TextSelector, ValueSelector, SelectionMode.Single, SelectedValue, ItemTemplate, AriaLabel, MaxHeight  
**Tests:** U-016, U-042, P-001, A-003

```razor
@page "/list/employee-directory"
@using Syncfusion.Blazor.Toolkit

<SfList TItem="Emp"
        DataSource="@employees"
        TextSelector="e => e.Name"
        ValueSelector="e => e.Id"
        SelectionMode="ListSelectionMode.Single"
        @bind-SelectedValue="selected"
        AriaLabel="Employee directory"
        MaxHeight="360px">
    <ItemTemplate>
        <div class="e-list-line">
            <span class="e-avatar">@context.Initials</span>
            <div>
                <div>@context.Name</div>
                <div class="e-secondary">@context.Title · @context.Dept</div>
            </div>
        </div>
    </ItemTemplate>
</SfList>
@if (selected is not null)
{
    <p>Selected: <strong>@selected.Name</strong></p>
}
@code {
    record Emp(string Id, string Name, string Title, string Dept, string Initials);
    Emp? selected;
    List<Emp> employees = new()
    {
        new("1", "Alice Chen", "Senior Engineer", "Engineering", "AC"),
        new("2", "Bob Diaz", "Product Designer", "Design", "BD"),
        new("3", "Carol Evans", "Engineering Manager", "Engineering", "CE")
    };
}
```

**Expected:** Avatar and supporting text; one selected item; role=listbox.

---

## Sample 02 – Task checklist

**Story:** US-06  
**Scenario:** Check tasks without selecting them.  
**APIs:** TextField, CheckMode, CheckedValues, SelectionMode.None, Density, AriaLabel  
**Tests:** U-062, U-063, A-001

```razor
@page "/list/task-checklist"
@using Syncfusion.Blazor.Toolkit

<SfList TItem="TaskItem"
        DataSource="@tasks"
        TextField="Title"
        CheckMode="ListCheckMode.Multiple"
        @bind-CheckedValues="checkedTasks"
        SelectionMode="ListSelectionMode.None"
        AriaLabel="Sprint tasks"
        Density="ListDensity.Comfortable">
    <ItemTemplate>
        <div class="e-list-line">
            <span>@context.Title</span>
            <span class="e-badge">@context.Priority</span>
        </div>
    </ItemTemplate>
</SfList>
@code {
    record TaskItem(string Title, string Priority);
    List<TaskItem> tasks = new()
    {
        new("Design review", "High"),
        new("Implement API", "Medium"),
        new("Write tests", "High")
    };
    IEnumerable<TaskItem>? checkedTasks;
}
```

**Expected:** role=list; checks do not set aria-selected.

---

## Sample 03 – Settings navigation

**Story:** US-09, US-10  
**Scenario:** Side navigation with links and one expandable section.  
**APIs:** SelectionMode.None, Href, NestedList, Expanded, AriaLabel  
**Tests:** U-065, U-118, A-002, P-005

```razor
@page "/list/settings-nav"
@using Syncfusion.Blazor.Toolkit

<SfList TItem="object" AriaLabel="Settings" SelectionMode="ListSelectionMode.None">
    <SfListItem Text="Account" Href="/settings/account" />
    <SfListItem Text="Billing" Href="/settings/billing" />
    <SfListItem Text="Preferences" @bind-Expanded="prefsExpanded">
        <NestedList>
            <SfList TItem="object" SelectionMode="ListSelectionMode.None" AriaLabel="Preference links">
                <SfListItem Text="Notifications" Href="/settings/notifications" />
                <SfListItem Text="Theme" Href="/settings/theme" />
            </SfList>
        </NestedList>
    </SfListItem>
</SfList>
@code { bool prefsExpanded = true; }
```

**Expected:** role=list; expanded section exposes aria-expanded; nested links stay in tab order.

---

## Sample 04 – Contact groups

**Story:** US-08  
**Scenario:** Contacts grouped by department. The consumer supplies already ordered data. The list does not sort.  
**APIs:** TextField, GroupField, GroupTemplate, ItemTemplate, AriaLabel  
**Tests:** U-011, U-023, U-036, A-005

```razor
@page "/list/contact-groups"
@using Syncfusion.Blazor.Toolkit

<SfList TItem="Contact"
        DataSource="@contacts"
        TextField="Name"
        GroupField="Dept"
        AriaLabel="Contacts by department">
    <GroupTemplate><strong>@context</strong></GroupTemplate>
    <ItemTemplate>
        <div class="e-list-line">
            <span>@context.Name</span>
            <span class="e-secondary">@context.Email</span>
        </div>
    </ItemTemplate>
</SfList>
@code {
    record Contact(string Name, string Dept, string Email);
    List<Contact> contacts = new()
    {
        new("Alice Chen", "Engineering", "alice@contoso.com"),
        new("Bob Diaz", "Engineering", "bob@contoso.com"),
        new("Cara Evans", "Sales", "cara@contoso.com")
    };
}
```

---

## Sample 05 – Multi-select queue

**Story:** US-05, US-20  
**Scenario:** Agents select tickets. Reordering the bound collection is host code, not a list drag feature.  
**APIs:** TextSelector, ItemKey, SelectionMode.Multiple, SelectedValues, AriaLabel, MaxHeight  
**Tests:** U-031, U-043, P-002

```razor
@page "/list/ticket-queue"
@using Syncfusion.Blazor.Toolkit

<SfList TItem="Ticket"
        DataSource="@tickets"
        TextSelector="t => t.Title"
        ItemKey="t => t.Id"
        SelectionMode="ListSelectionMode.Multiple"
        @bind-SelectedValues="selected"
        AriaLabel="Priority queue"
        MaxHeight="400px">
    <ItemTemplate>
        <div class="e-list-line">
            <span class="e-badge">@context.Priority</span>
            <div>
                <div>@context.Title</div>
                <div class="e-secondary">@context.Customer</div>
            </div>
        </div>
    </ItemTemplate>
</SfList>
@code {
    record Ticket(string Id, string Title, string Customer, string Priority);
    List<Ticket> tickets = new()
    {
        new("T1", "Login failure", "Acme Corp", "P1"),
        new("T2", "Billing mismatch", "Globex", "P2")
    };
    IEnumerable<Ticket>? selected;
}
```

---

## Sample 06 – Large inventory

**Story:** US-12  
**Scenario:** Browse a large SKU list with multiple selection. Selection is host state. The component does not persist it.  
**APIs:** EnableVirtualization, ItemKey, TextSelector, SelectionMode.Multiple, SelectedValues, MaxHeight, AriaLabel  
**Tests:** U-099, U-100, P-046, PERF-001

```razor
@page "/list/inventory"
@using Syncfusion.Blazor.Toolkit

<SfList TItem="Sku"
        DataSource="@skus"
        TextSelector="s => s.Name"
        ItemKey="s => s.SkuId"
        EnableVirtualization="true"
        SelectionMode="ListSelectionMode.Multiple"
        @bind-SelectedValues="selected"
        MaxHeight="480px"
        AriaLabel="Inventory">
    <ItemTemplate>
        <div class="e-list-line">
            <span>@context.SkuId</span>
            <div>@context.Name</div>
            <span class="e-badge">@context.Qty</span>
        </div>
    </ItemTemplate>
</SfList>
@code {
    record Sku(string SkuId, string Name, int Qty);
    List<Sku> skus = Enumerable.Range(1, 5000)
        .Select(i => new Sku($"SKU-{i:D5}", $"Item {i}", i % 500))
        .ToList();
    IEnumerable<Sku>? selected;
}
```

---

## Sample 07 – Notifications

**Story:** US-11  
**Scenario:** Empty, loading, and error states.  
**APIs:** TextField, IsLoading, HasError, HeaderTemplate, EmptyTemplate, LoadingTemplate, ErrorTemplate, AriaLabel  
**Tests:** U-001, U-002, U-003, P-060

```razor
@page "/list/notifications"
@using Syncfusion.Blazor.Toolkit

<SfList TItem="Note"
        DataSource="@notes"
        TextField="Title"
        IsLoading="@loading"
        HasError="@error"
        AriaLabel="Notifications">
    <HeaderTemplate><h2>Notifications</h2></HeaderTemplate>
    <EmptyTemplate><div class="e-list-empty">No notifications</div></EmptyTemplate>
    <LoadingTemplate><div class="e-list-loading">Loading notifications</div></LoadingTemplate>
    <ErrorTemplate>
        <div class="e-list-error" role="alert">
            Failed to load. <button type="button" @onclick="Retry">Retry</button>
        </div>
    </ErrorTemplate>
    <ItemTemplate>
        <div class="e-list-line">
            <div>@context.Title</div>
            <div class="e-secondary">@context.Time</div>
        </div>
    </ItemTemplate>
</SfList>
@code {
    bool loading = true;
    bool error;
    record Note(string Title, string Time);
    List<Note> notes = new();

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(300);
        loading = false;
        notes = new() { new("Build succeeded", "15 min ago") };
    }

    void Retry()
    {
        error = false;
        loading = true;
    }
}
```

---

## Sample 08 – Dense RTL list

**Story:** US-14, US-16, US-18  
**Scenario:** Dense order history inside an RTL container. RTL comes from `dir`, not a component parameter.  
**APIs:** TextSelector, Density, AriaLabel, MaxHeight  
**Tests:** U-017, P-037, A-012

```razor
@page "/list/order-history"
@using Syncfusion.Blazor.Toolkit

<div dir="rtl">
    <SfList TItem="Order"
            DataSource="@orders"
            TextSelector="o => o.Id"
            Density="ListDensity.Dense"
            AriaLabel="Order history"
            MaxHeight="70vh">
        <ItemTemplate>
            <div class="e-list-line">
                <div>
                    <div>@context.Id</div>
                    <div class="e-secondary">@context.Date · @context.Status</div>
                </div>
                <span class="e-badge">@context.Total</span>
            </div>
        </ItemTemplate>
    </SfList>
</div>
@code {
    record Order(string Id, string Date, string Status, string Total);
    List<Order> orders = new()
    {
        new("#1042", "2026-10-28", "Shipped", "$128.00"),
        new("#1041", "2026-10-25", "Delivered", "$89.50")
    };
}
```

---

## Registration

Follow the existing sample browser under `samples/Blazor.Toolkit.Samples`. Confirm the navigation entry during implementation. Do not add a sort, drag, or persistence sample.
