# Drumming Practice App Documentation

## Project Overview
**Repository Location:** D:\Repositories\DrumPractice  
**Technology Stack:** .NET MAUI Blazor Hybrid, C#, SQLLite

---

# Core Features

## 1. Exercise Management

### 1.1 Rudiments
**Supported Patterns/Tags:**
- Rolls, Diddles, Flams, Drags

**Needed Improvements:**
- Progression tracking implementation:
  - We track the Title, set bpm and the number of seconds practiced for every practice that is logged. In addition we ask for a rating of 1-5 stars to indicate how the practice felt.

### 1.2 Generic Exercises
**User-Created Content:**
- Title and description required
- Image and video support (URLs)
- Tag system: Rolls/Diddles/Flams/Drags -> Primarely used for the rudiments.
  - Song/Fill/Drumeo/Hands/Feet/Single Pedal/Double Bass tags are used for better search and overview purposes.

### 1.3 Fills
**Pattern Types:**
- ABCD fill patterns
  - Short blocks of Notes (Being images in this case) can be orchestrated in a random order or put in a order of choosing to create a Fill.
  - Block-based (image) combinations
- Single/double strokes
- Paradiddles (RLLK variations)
- Cool Fills can I be added as an exercise with the Fill tag. They have the same properties -> Title, description, imageUrl, VideoUrl
  
**Features Needed:**
- Block library management
- Random generation algorithms

### 1.4 Books & Pages
These will be harder to view on a Image. Maybe for books we can in time extend our practice logs with:
**Page-Based System:**
- Chapter organization
- Completion tracking
- Page reference system

### 1.5 Songs
**Complete Music Pieces:**
- Mainly to have a overview of the time spend practicing a song.
- Could have images of specific sections in the song to practice individually

---

# Practice Tracking Systems

## Timer Management
| Method | Functionality |
|--------|---------------|
| **Timer** | Pre-set durations (30min, 1h, custom) |
| **Stopwatch** | Manual start/stop tracking |
| **Manual Entry** | Historical time recording |

## BPM Tracking
- The bpm can be set by the user. 
- After an exercise is selected for wich there are logs we can suggest a BPM value based on the previous BPM value and the rating given for that practice session. If it went well (4 or 5 stars) we can raise the BPM. If it went poorly (1 or 2 stars) we can the BPM.
- Historical trend analysis
- Visual progression indicators

**Star Icon System:**
  1 => "Rough session",
  2 => "Needs work",
  3 => "Getting there",
  4 => "Solid practice",
  5 => "Nailed it!",
  _ => "Tap to rate"

---

# Tag Management System

## Tag Operations
- Create, delete, rename tags
- Hierarchy and organization
- Filter combinations:
  - "Beginner AND (Rudiments OR Right Hand)"
  - "Intermediate AND NOT Beginner"
  - "Songs AND (Advanced OR Intermediate)"

## Current Tags Associations example
| Exercise ID | Associated Tags |
|-------------|----------------|
| 1 | Rudiment, Diddle |
| 2 | Rudiment, Diddle |
| 3 | Rudiment, Flams  |
| 4 | Book             |
| 5 | Song, Double Bass|

---
