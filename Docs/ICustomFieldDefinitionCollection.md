# ICustomFieldDefinitionCollection

A collection of custom field definitions.

**Assembly:** Manatee.Trello.dll

**Namespace:** Manatee.Trello

**Inheritance hierarchy:**

- ICustomFieldDefinitionCollection

## Methods

### Task&lt;ICustomFieldDefinition&gt; Add(string name, CustomFieldType type, CancellationToken ct, IDropDownOption[] options)

Adds a new custom field definition to a board.

**Parameter:** name

The field&#39;s name.

**Parameter:** type

The field&#39;s data type.

**Parameter:** ct

(Optional) A cancellation token for async processing.

**Parameter:** options

(Optional) A collection of drop down options.

**Returns:** The [ICustomFieldDefinition](ICustomFieldDefinition#icustomfielddefinition) generated by Trello.
