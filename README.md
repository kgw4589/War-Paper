# War Paper
![Image](https://github.com/user-attachments/assets/56d087da-882f-43a3-a377-83f467031e4a)

## 개요
게임 엔진 수업 수행평가를 위해 제작되었습니다. 2D 슈팅(like.스트라이커즈 1945) -> 3D 비행 시뮬레이터(like.War Thunder)로 발전시켰습니다.
War paper는 '워 썬더'를 벤치마킹한 1인용 비행 슈팅 게임입니다.
종이 비행기를 조종하여 적 미사일을 요격해 살아남고, 비행기를 격추시켜 점수를 얻는 게임입니다.
적 기체 요격 시 일정 확률로 생성되는 아이템을 얻어 공격 향상, 이동 속도 항샹, 궁극기 효과를 얻을 수 있습니다.

| **수업 내용** | **만든 것** |
|:---:|:---:|
| ![Image](https://github.com/user-attachments/assets/b1e8a41d-171b-4410-86bc-2baa68d1054b) | ![Image](https://github.com/user-attachments/assets/9b96a0f0-6b33-4034-b74a-4cbc7beef42f) | 


**장르**   
비행 시뮬레이터, 슈팅

**개발 인원**   
총원 1명(게임 클라이언트 1명)

**개발 기간**   
2024.11.23. ~ 2024.11.24.

**참고자료**   
- 플레이 영상(평가 제출용) : <https://youtu.be/Xk6Na248sew>
- 원래 수업 내용 영상 : <https://youtu.be/I60KI4tuLOI>

---

## 개발 환경
| **용도** | **기술 스펙** | **선정 이유** |
|:---:|:---:|:---:|
| **게임 엔진** | **`Unity 3D 2022.3.17f1`**  | 수행평가의 간단한 게임 제작 용도로 적합.</br> 크로스 플랫폼, 다양한 기능 제공.</br> 22.3.X 버전이 대부분의 프로젝트에서 안정적. |
| **IDE** | `Jetbrains Rider` | 다양한 기능 제공, 학생 라이선스 무료.    |
| **저장소** | `Github, Github Desktop` | 사용 경험. 다양한 기능 제공. 무료. |


---

## 주요 기능 및 사용 방법
**기본 이동**   
기체는 자동으로 전진함.   
* 마우스를 앞으로 밀어 기체의 앞을 들 수 있음.
* 마우스를 아래로 당겨 기체의 앞을 밑으로 내릴 수 있음.
* 마우스를 좌우로 이동하여 기체를 Z축 회전시킬 수 있음.   
![Image](https://github.com/user-attachments/assets/56de8dde-a769-4cd6-a9b6-aca83c6eb615)

**부스터**
* 좌 Shift를 홀드하여 빠른 속도로 이동 가능.
* 부스터 사용 시, 연료를 소모함.
* 현재 연료는 화면 하단에 표시됨.   
![Image](https://github.com/user-attachments/assets/4cd67bae-8452-41d0-ae41-ce5be1d69568)

**카메라**
* V키를 눌러 카메라 시점을 변경할 수 있음(1인칭, 3인칭)
* 요격 혹은 격추 시 카메라가 흔들림
* 기체의 속도에 따라 Camera의 Field of View 수치를 조절하여 속도감을 나타냄   
![Image](https://github.com/user-attachments/assets/8f316c52-3ab3-4260-9aa2-63739a3327a3)

**기본 공격**   
* 마우스 좌클릭으로 미사일을 발사할 수 있음. GetButton 방식.

**궁극기**   
* 궁극기가 준비 상태일 때, Z키를 눌러 궁극기를 시전할 수 있음.
* 궁극기 시전 시, 상대의 모든 미사일과 기체가 폭발하며 점수를 얻음.
![Image](https://github.com/user-attachments/assets/632d6e84-b7f9-4340-96c6-79fab7059c89)

### 아이템   
모든 아이템은 적 기체 요격 시 일정 확률로 폭발 위치에 생성됨.
아이템은 플레이어의 비행기와 충돌 시 자동으로 획득.   

**공격 강화(30%)**   
* 기본 공격으로 발사하는 미사일의 수가 증가됨.
* 1 > 3 > 5 > 7 순서로 강화.
* 부채꼴 모양으로 발사.    
![Image](https://github.com/user-attachments/assets/2f6ff1bc-22f3-4ede-bd6f-18481b4e7cdf)

**이동 강화(30%)**
* 기본 이동속도가 증가함.
* 최대 3회 강화할 수 있음.
* 강화 시, 초기 이동속도(5000km/h)의 10%(500km/h)가 증가함.      
![Image](https://github.com/user-attachments/assets/cf446051-628e-48d3-bcb2-b1bf5a8fc285)

**연료**
* 부스터 사용을 위한 연료를 획득할 수 있음.
* 최대치의 반틈 획득(단, 초과분은 버림).    
![Image](https://github.com/user-attachments/assets/89c49b82-c26f-4795-9652-947d2b08a2f3)

**궁극기**
* 궁극기가 준비됨.    
![Image](https://github.com/user-attachments/assets/426d724f-f577-442b-b101-e9231b2a25e7)

---

## 라이선스
본 프로젝트는 단순 학습의 **비상업적 용도**로 제작되었습니다.

### 코드
- 본 프로젝트의 코드는 MIT 라이선스 하에 제공됩니다.

- 사용된 **비코드 에셋(모델, 이미지, 사운드 등)** 은 각각의 라이선스를 따릅니다.  

### Sketchfab 에셋

본 프로젝트는 다음과 같은 Sketchfab 모델을 사용하였습니다:

| 모델명 | 라이선스 | 링크 | 원작자 |
|:--|:--|:--|:--|
| AH-64 Apache | CC Attribution | [링크](https://sketchfab.com/3d-models/ah-64-apache-df0993ee21e74a759cd0519f6fc51cf8) | [Aerofiles](https://sketchfab.com/aerofiles) |
| Airplane Engine | CC Attribution | [링크](https://sketchfab.com/3d-models/airplane-engine-bb658020350e461aa8d915bc58cd6ef9) | [Polocho](https://sketchfab.com/polocho) |
| Wii U Super Mario Cat Bullet Bill | CC Attribution | [링크](https://sketchfab.com/3d-models/wii-u-super-mario-3d-world-cat-bullet-bill-3669a43924164e859ae259ea60f14124) | [Jakub Kaczmarek](https://sketchfab.com/jakubkaczmarek) |
| F-15C Pixy | CC Attribution | [링크](https://sketchfab.com/3d-models/f-15-c-pixy-b31c02e554f74ab68aa8610334c744c3) | [Junker](https://sketchfab.com/junker) |
| Heatseeker Air-to-Air Missile | CC Attribution | [링크](https://sketchfab.com/3d-models/heatseeker-air-air-missile-e9c5bba6f3b34f73b22961a726667856) | [Miguel Gant](https://sketchfab.com/miguel-gant) |
| Fuel Tank | CC Attribution-NonCommercial | [링크](https://sketchfab.com/3d-models/fuel-tank-04aa79ec53634c8faa5a10bd46912b9e) | [DavidF](https://sketchfab.com/davidf) |
| Nuclear Bomb (Stylized Low Poly) | CC Attribution | [링크](https://sketchfab.com/3d-models/nuclear-bomb-stylized-lowpoly-c9eaffc0b9d743e68fe8332d4ff97f9e) | [Square](https://sketchfab.com/square) |
| Plane Paper Rig | CC Attribution-NonCommercial | [링크](https://sketchfab.com/3d-models/plane-paper-rig-arnoldredshifrendrmnvray-ad9435c74da940049d630d16e02e3d13) | [Arnoldredshifrendrmnvray](https://sketchfab.com/arnoldredshifrendrmnvray) |
| WWII Soviet Plane (With Interior) | CC Attribution | [링크](https://sketchfab.com/3d-models/wwii-soviet-plane-with-interior-5590f0f0525d437a88e0232e5f8dd393) | [Alan](https://sketchfab.com/alan) |

> - **CC Attribution**: 원작자 표시 필수, 상업적 이용 가능  
> - **CC Attribution-NonCommercial**: 원작자 표시 필수, **비상업적 용도에만 사용 가능**


### 포함되지 않은 에셋
- `Assets/08.AssetStore` 폴더 내 모든 콘텐츠는 저작권 문제로 GitHub에 포함하지 않았습니다.
- 이 폴더는 Unity Asset Store에서 무료로 배포된 다음의 에셋을 포함하고 있습니다:
  - **AurynSky - Free Island Collection**
  - **True Explosions**
  - **AurynSky - Stylized Environment Assets**

> 위 에셋들은 Unity에서 정한 [Asset Store EULA](https://unity3d.com/legal/as_terms) 및 비재배포 조항에 따라 저장소에서 제외되었습니다. 단, 스크린샷 및 영상에는 등장할 수 있으며, 이는 Unity 측 라이선스에 위배되지 않습니다.
