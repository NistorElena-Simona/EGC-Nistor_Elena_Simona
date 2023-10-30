# Nistor Elena-Simona, gr 3131B

1.  **Care este ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)? Desenați axele de coordonate din aplicația- template folosind un singur apel GL.Begin().**
- Ordinea în care vertex-urile sunt desenate este acea in care apelăm metodele GL.Vertex. Dacă este anti-orar, atunci considerăm ca poligonul este cu fața către utilizator.
 2.  **Ce este anti-aliasing? Prezentați această tehnică pe scurt.**
 - Anti-aliasing este o metodă pentru a reduce artefactele vizuale care apar când randăm imagini la rezoluții mai mici. Aceste artefacte sunt cauzate de pixelii care nu pot reprezenta suprafețe curbate, linii, etc. prea bine.

- Anti-aliasing funcționează prin folosirea supersampling, multisampling sau post-processing filters.
3. **Care este efectul rulării comenzii GL.LineWidth(float)? Dar pentru GL.PointSize(float)? Funcționează în interiorul unei zone GL.Begin()**
 - GL.LineWidth(float) - mărește grosimea liniilor desenate. GL.PointSize(float)  mărește mărimea punctelor desenate. Aceste metode nu funcționează în interiorul zonei GL.Begin().
4.  **Răspundeți la următoarele întrebări (utilizați ca referință eventual și tutorii OpenGL Nate Robbins):**
 > Care este efectul utilizării directivei LineLoop atunci când sunt desenate segmente de dreaptă multiple în OpenGL?
 - Se vor desena linii, unde al doilea punct al unei linii, va fi folosit ca primul punct al următoarei linii. Iar la final se vor uni primul și ultimul punct pentru a crea o buclă.
  > Care este efectul utilizării directivei LineStrip atunci când sunt desenate segmente de dreaptă multiple în OpenGL
  - La fel ca la line loop, doar că ultimul și primul punct nu vor fi unite.
  > Care este efectul utilizării directivei TriangleFan atunci când sunt desenate segmente de dreaptă multiple în OpenGL?
  - Se va defini un punct central, iar apoi punctele din jurul acestui punct se vor unit cu cel central, la fel ca un ventilator.
  > Care este efectul utilizării directivei TriangleStrip atunci când sunt desenate segmente de dreaptă multiple în OpenGL?
  - Va face ca un punct să fie conectat la ultimele 2 puncte, la fel ca o fâșie (strip).
 
  5.   **Urmăriți aplicația „shapes.exe” din tutorii OpenGL Nate Robbins. De ce este importantă utilizarea de culori diferite (în gradient sau culori selectate per suprafață) în desenarea obiectelor 3D? Care este avantajul?**
  Deoarece fără umbre sau shadere, nu vom percepe nici-o forma, ci doar o simgură culoare într-o formă ciudată.
 6. **Ce reprezintă un gradient de culoare? Cum se obține acesta în OpenGL?**
  Un gradient reprezintă o trecere liniară de la o culoare la alta. Pentru a obține aceste efect în OpenGL, putem da culori diferite vertex-elor cand desenăm poligoane.