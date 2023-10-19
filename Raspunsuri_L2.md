# Răspuns la întrebări Laborator 2 EGC

1. Fiind o constantă, valoarea acesteia nu se poate modifica.
2. - Ce este un viewport?
 *Un viewport este regiunea unde este generată imaginea grafică*
    - Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii OpenGL?
    *Frames per seconds se referă la numărul de cadre consecutive pe secundă*
    - Când este rulată metoda OnUpdateFrame()?
    *Metoda OnUpdateFrame() este rulată când se dorește să fie actualizat cadrul (scena) la un interval fix*
    - Ce este modul imediat de randare?
    *Modul imediat de randare este redarea în mod imediat, ceea ce înseamnă că obiectele pot fi afișate după ce sunt descrise, fără a fi necesar ca mai întâi să se completeze o listă de display, făcând referire la apelurile clientului.*
    - Care este ultima versiune de OpenGL care acceptă modul imediat?
    *OpenGL4.6.*
    - Când este rulată metoda OnRenderFrame()? 
    *Metoda OnRenderFrame() este rulată atunci când se dorește desenarea unui obiect de bază.*
    - De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
    *Este nevoie ca metoda OnResize() să fie executată cel puțin odată pentru a putea umple scena și a fi înregistrat evenimentul.*
    - Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?
    *  Are următorii parametri :  fovy(definește cât de larg e spațiul de redare, adică unghiul câmpului vizual, cu valori între 1-179 grade), aspect ratio( se împarte grosimea la înălțime, respectiv are valori mai mari de 0) și încă 2 parametri, zNear și zFar, care setează distanța până la cel mai apropiat plan, respective îndepărtat.*