---
category: Components
type: Data Entry
title: AutoComplete
cover: https://gw.alipayobjects.com/zos/alicdn/qtJm4yt45/AutoComplete.svg
---

Autocomplete function of input field.

## When To Use

When there is a need for autocomplete functionality.

## API

### AutoComplete

| ���� | ˵�� | ���� | Ĭ��ֵ | �汾 |
| --- | --- | --- | --- | --- |
| `Backfill` | backfill selected item the input when using keyboard | `boolean` | `false` |
| `DataSource` | Data source for autocomplete | `AutocompleteDataSource` | - |
| `DefaultActiveFirstOption` | Whether active first option by default | `boolean` | `true` |
| `Width` | Custom width, unit px | `int` | ����Ԫ�ؿ�� |
| `OverlayClassName` | Class name of the dropdown root element | `string` | - |
| `OverlayStyle` | Style of the dropdown root element | `object` | - |
| `CompareWith` | `(o1: object, o2: object) => bool` | `(o1: object, o2: object) => o1===o2` |


### AutoCompleteOption

| ���� | ˵�� | ���� | Ĭ��ֵ |
| --- | --- | --- | --- |
| `Value` | bind ngModel of the trigger element | `object` | - |
| `Label` | display value of the trigger element | `string` | - |
| `Disabled` | disabled option | `boolean` | `false` |

