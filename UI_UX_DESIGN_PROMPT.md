# UI/UX Design Prompt - Brisa Vehicle Dashboard

## 🎨 Proje Genel Bakış

**Proje Adı:** Brisa Vehicle Dashboard  
**Tip:** Enterprise Data Management Dashboard  
**Platform:** Web Application (Blazor Server)  
**Kullanım Amacı:** Araç verilerini görüntüleme, arama ve yönetim

---

## 📋 Tasarım İhtiyaçları

### Ana Bileşenler

1. **Header Bölümü**
   - Logo veya başlık alanı
   - Dashboard başlığı ve kısa açıklama
   - Sağ tarafta arama kutusu (glassmorphism veya minimalist)
   - Beyaz/minimal arka plan

2. **İstatistik Kartları (5 adet)**
   - Grid layout: 5 eşit kart
   - Her kart: büyük sayı, kategori adı
   - Sol kenarda ince renkli accent çizgisi
   - Hover efektleri: hafif yukarı kalkma, gölge artışı
   - Kartlar tıklanabilir (tab navigasyonuna yönlendirir)

3. **Tab Navigasyonu**
   - Horizontal tab menu
   - Aktif tab: mavi arka plan, beyaz yazı
   - Pasif tablar: şeffaf arka plan, gri yazı
   - Yuvarlatılmış köşeler (8-12px radius)
   - Smooth hover transitions

4. **Veri Tabloları**
   - Okunabilir satır ve sütunlar
   - Sticky header
   - Alternatif satır renkleri (çok hafif)
   - Hover: satır highlight efekti
   - İnce border'lar
   - "Detay" butonları her satırda

5. **Modal/Detay Penceresi**
   - Overlay: koyu blur arka plan
   - Modal: beyaz arka plan, yuvarlatılmış köşeler
   - Header: başlık + kapatma butonu
   - Body: yapılandırılmış detay kartları (field-label + field-value)

6. **Pagination**
   - Minimal pagination kontrolleri
   - Sayfa numaraları, önceki/sonraki butonları
   - Aktif sayfa highlight

---

## 🎨 Renk Paleti

### Primary Colors
- **Primary Blue:** `#2563eb` (Ana vurgu rengi, butonlar, aktif tablar)
- **Primary Dark:** `#1e40af` (Hover durumları)
- **Primary Light:** `#3b82f6` (İkincil vurgular)

### Neutral Grays
- **Text Primary:** `#0f172a` (Ana metinler)
- **Text Secondary:** `#475569` (İkincil metinler)
- **Text Tertiary:** `#94a3b8` (Placeholder, yardımcı metinler)
- **Border Light:** `#e2e8f0` (İnce border'lar)
- **Border Medium:** `#cbd5e1` (Orta kalınlık border'lar)

### Background Colors
- **BG Primary:** `#ffffff` (Ana arka plan)
- **BG Secondary:** `#f8fafc` (Alternatif arka planlar)
- **BG Tertiary:** `#f1f5f9` (Tab header, modal header)

### Accent Colors (Kartlar için)
- **Brand Card:** Primary Blue
- **Group Card:** Sky Blue `#0ea5e9`
- **Model Card:** Amber `#eab308`
- **Year Card:** Green `#22c55e`
- **Version Card:** Red `#ef4444`

---

## 🎯 Tasarım Prensipleri

### 1. Minimalism & Clean
- Gereksiz dekorasyon yok
- Sade, odaklanmış tasarım
- Beyaz boşluklar efektif kullanımı

### 2. Professional & Enterprise
- Ciddi, iş dünyasına uygun görünüm
- Tutarlı renk kullanımı
- Kurumsal tipografi

### 3. Readability First
- Yüksek kontrast oranları
- Okunabilir font boyutları (min 14px)
- Net hiyerarşi (başlıklar, metinler, etiketler)

### 4. Subtle Interactions
- Hafif hover efektleri
- Smooth transitions (150-300ms)
- Görsel geri bildirimler (butonlar, kartlar)

### 5. Modern UI Patterns
- Yuvarlatılmış köşeler (8-16px)
- İnce gölgeler (soft shadows)
- Glassmorphism (sadece arama kutusu için, opsiyonel)

---

## 📐 Layout & Spacing

### Grid System
- 12-column grid (responsive)
- Breakpoints: Mobile (768px), Tablet (1024px), Desktop (1280px+)

### Spacing Scale
- **XS:** 4px (0.25rem)
- **SM:** 8px (0.5rem)
- **MD:** 16px (1rem)
- **LG:** 24px (1.5rem)
- **XL:** 32px (2rem)
- **2XL:** 48px (3rem)

### Component Spacing
- Header: 32px padding
- Cards: 24px padding, 24px gap
- Tables: 16px cell padding
- Modal: 32px padding

---

## 🔤 Typography

### Font Stack
```
System Font Stack:
-apple-system, BlinkMacSystemFont, 'Segoe UI', 'Roboto', 
'Oxygen', 'Ubuntu', 'Cantarell', 'Fira Sans', sans-serif
```

### Font Sizes
- **H1 (Header):** 32px / 2rem (bold, 700)
- **H2 (Section):** 24px / 1.5rem (semibold, 600)
- **H3 (Modal):** 20px / 1.25rem (semibold, 600)
- **Body:** 14px / 0.875rem (regular, 400)
- **Small:** 12px / 0.75rem (medium, 500)
- **Stat Numbers:** 36px / 2.25rem (bold, 700, tabular-nums)

### Font Weights
- **Regular:** 400
- **Medium:** 500
- **Semibold:** 600
- **Bold:** 700

---

## ✨ Visual Effects

### Shadows
- **XS:** `0 1px 2px rgba(15, 23, 42, 0.03)`
- **SM:** `0 1px 3px rgba(15, 23, 42, 0.08), 0 1px 2px rgba(15, 23, 42, 0.04)`
- **MD:** `0 4px 6px rgba(15, 23, 42, 0.08), 0 2px 4px rgba(15, 23, 42, 0.04)`
- **LG:** `0 10px 15px rgba(15, 23, 42, 0.08)`
- **XL:** `0 20px 25px rgba(15, 23, 42, 0.08)`

### Border Radius
- **SM:** 6px (küçük butonlar, input'lar)
- **MD:** 8px (kartlar, tab'lar)
- **LG:** 12px (ana container'lar)
- **XL:** 16px (modal)

### Transitions
- **Fast:** 150ms (hover durumları)
- **Base:** 200ms (genel geçişler)
- **Slow:** 300ms (modal açılma, büyük animasyonlar)

---

## 📱 Responsive Behavior

### Mobile (< 768px)
- Tek sütun layout
- Kartlar full-width
- Tab'lar yatay scroll
- Modal full-screen
- Kompakt spacing

### Tablet (768px - 1024px)
- 2 sütun grid (kartlar için)
- Tam genişlik tablolar
- Modal 90% genişlik

### Desktop (> 1024px)
- 5 sütun grid (kartlar)
- Sabit genişlik modal (800px)
- Tam özellik seti

---

## 🎭 Animation & Interaction

### Hover States
- **Cards:** `translateY(-2px)` + shadow artışı
- **Buttons:** Background color değişimi
- **Table Rows:** Hafif background highlight
- **Tabs:** Background + color transition

### Active States
- **Tab:** Primary blue background + white text
- **Button:** Primary blue background
- **Input Focus:** Blue border + ring shadow

### Loading States
- Spinner: 40px, primary blue border
- Fade-in animation (300ms)
- Skeleton loader (opsiyonel)

---

## 🖼️ Reference Style

**Stil Karakteristiği:**
- **Linear Dashboard** (https://linear.app) - Minimal, temiz
- **Notion** (https://notion.so) - Basit, işlevsel
- **Vercel Dashboard** - Modern, profesyonel
- **Stripe Dashboard** - Kurumsal, güvenilir

**Kaçınılacak Stiller:**
- Aşırı renkli, gradient dolu tasarımlar
- Neon renkler, parlak efektler
- Çok karmaşık animasyonlar
- Bold, agresif tasarımlar

---

## 🎨 Final Design Prompt (AI Tools için)

```
Design a modern, professional data dashboard interface for vehicle data management system. 

Layout: Clean white background with subtle gray accents. Top header section with title and search bar. Five clickable stat cards in a horizontal grid showing large numbers with category labels, each with a thin colored accent line on the left edge. Below, a horizontal tab navigation with rounded tabs (active tab has blue background, inactive tabs are transparent). Main content area with a clean data table featuring readable rows with alternating subtle backgrounds, sticky header, and detail buttons in each row.

Color Palette: Primary blue (#2563eb), neutral grays (#0f172a to #94a3b8), white backgrounds. Accent colors: blue, sky blue, amber, green, red for different stat cards.

Design Style: Minimalist, enterprise-grade, professional. Similar to Linear, Notion, or Vercel dashboards. Subtle shadows (0 1px 3px rgba(15, 23, 42, 0.08)), rounded corners (8-16px), smooth transitions (200ms). Clean typography with system font stack. No gradients, no excessive colors, no neon effects.

Interaction: Subtle hover effects on cards (slight lift, shadow increase), smooth tab transitions, table row highlighting on hover. Modal overlay with dark blurred background and white rounded modal container.

Responsive: Mobile-first approach with single column layout on small screens, expanding to grid layout on desktop.

Visual Hierarchy: Clear distinction between header (title), stats (cards), navigation (tabs), and content (table). Proper spacing using 8px grid system.
```

---

## ✅ Design Checklist

- [ ] Header: Temiz, minimal, arama kutusu sağda
- [ ] Stat Cards: 5 kart, sol accent çizgisi, hover efektleri
- [ ] Tabs: Yatay navigasyon, aktif/pasif durumlar
- [ ] Tables: Okunabilir, sticky header, hover efektleri
- [ ] Modal: Overlay + white container, detay kartları
- [ ] Colors: Primary blue + neutral grays
- [ ] Typography: System fonts, net boyutlar
- [ ] Spacing: 8px grid system
- [ ] Shadows: Subtle, professional
- [ ] Responsive: Mobile, tablet, desktop breakpoints
- [ ] Animations: Smooth, 200ms transitions

---

## 📝 Notlar

- Tasarım AI tarafından yapıldığı belli olmamalı
- Profesyonel, kurumsal görünüm öncelikli
- Veri yoğun içerik için optimize edilmiş
- Accessibility (erişilebilirlik) standartlarına uygun
- Performans: Hafif, hızlı yüklenen

---

**Hazırlayan:** AI Assistant  
**Tarih:** 2025-01  
**Proje:** Brisa Vehicle Dashboard
