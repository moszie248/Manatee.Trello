---
title: IPowerUpCollection
category: API
order: 151
---

A collection of power-ups.

**Assembly:** Manatee.Trello.dll

**Namespace:** Manatee.Trello

**Inheritance hierarchy:**

- IPowerUpCollection

## Methods

### Task DisablePowerUp(IPowerUp powerUp, CancellationToken ct = default(CancellationToken))

Disables a power-up for a board.

**Parameter:** powerUp

The power-up to disble.

**Parameter:** ct

(Optional) A cancellation token for async processing.

### Task EnablePowerUp(IPowerUp powerUp, CancellationToken ct = default(CancellationToken))

Enables a power-up for a board.

**Parameter:** powerUp

The power-up to enable.

**Parameter:** ct

(Optional) A cancellation token for async processing.
