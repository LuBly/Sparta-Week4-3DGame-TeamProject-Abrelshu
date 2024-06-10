# Project_Abrelshud - by.A07
![BGImage](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/ee2dc676-5bf5-4e96-8733-7e86d4da8707)

<br>

<div align="center">

# 목차

| [✈️ 프로젝트 소개(개발환경) ](#airplane-프로젝트-소개) |
| :---: |
| [✋ 팀 소개 ](#hand-팀-소개) |
| [💭 기획의도 ](#thought_balloon-기획의도) |
| [🌟 주요기능 ](#star2-주요기능) |
| [⏲️ 프로젝트 수행 절차 ](#timer_clock-프로젝트-수행-절차) |
| [🕹️ 기술 스택 ](#joystick-기술-스택) |
| [🕸️ 와이어프레임 ](#spider_web-와이어프레임) |
| [📓 UML ](#notebook-통합모델링-다이어그램) |
| [☑️ 트러블 슈팅 ](#ballot_box_with_check-트러블-슈팅) |

</div>

<br><br>

## :airplane: 프로젝트 소개

#### Team Notion을 클릭하시면, 프로젝트 진행 과정을 확인하실 수 있습니다!
### [🤝Team Notion]
(https://www.notion.so/teamsparta/f0403e46a9684921bdebf9976d82e406)

<br>

#### ${\textsf{\color{red}3D 퍼즐 플랫폼 게임}}$
### 아브렐슈드 5관문을 새롭게 체험할 기회!

<br>

<div align="center">

| 게임명 | **${\textsf{\color{blue}아브렐슈드 5관문}}$** |
| :---: | :---: |
| 장르 | 3D퍼즐 플랫폼 게임 |
| 개발 언어 | C# |
| 프레임워크 | .Net 4.8.04084 |
| 개발 환경 | Unity 2022.3.17f1 <br/> Visual Studio Community 2022 |
| 타겟 플랫폼 | PC |
| 개발 기간 | 2024.06.03 ~ 2024.06.10 |

</div>

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>

## :hand: 팀 소개

| 이름  | 직책 | Github | 블로그 | 담당 |
|-----|---| ---|---|---|
| 박현호 | 팀장 |<a href="https://github.com/LuBly">![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)</a>|https://velog.io/@lubly/posts | Boss
| 유승아 | 팀원 |<a href="https://github.com/YooSeungA52">![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)</a>|https://velog.io/@seunga52/posts | Player
| 김재혁 | 팀원 | <a href="">![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)</a>|https://jhk97.tistory.com/manage/posts/ | Audio, UI
| 박유창 | 팀원 | <a href="https://github.com/Fluency5427">![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)</a>|https://blog.naver.com/hyungji5427 | Audio, UI
---

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>

## :thought_balloon: 기획의도

### 1. 주제 선정 배경
플레이어와 적 객체 또는 아이템간의 상호작용및 숙련주차에서 배운 RayCast등을 활용할 수 있다고 판단해 선정하였다

### 2. 기존 유사 서비스와 차별화된 내용
지금까지 배운 지식으로 로스트아크 아브렐슈드 5관문을 최대한 재현한다

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>

## :star2: 주요기능

### 1. 플레이어
<table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/5668ecc1-623a-4adb-8e9f-d704bc1a42a9">
</a></td>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/99a2a469-bab8-4f6a-83ff-2244b932f31d"></a></td>
  </tr>
</table>

   - 마우스 우클릭을 이용하여 원하는 자리에 캐릭터를 움직시킵니다.
   - 캐릭터는 스페이스를 통해 일정거리를 대쉬할 수 있습니다.

<br>

***
     
### 2. 아이템 생성
<table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/06fc9800-7a7f-4b83-8f8d-a1fca9b70717"></a></td>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/c9c304d6-8685-4a78-8f92-74a69942ca07"></a></td>
  </tr>
</table>

   - 필드에 일정시간 마다 흰색과 검정색 원형 오브젝트가 생성됩니다.
   - 흰색 아이템을 획득하면 플레이어 머리위에 랜덤하게 문양이 생성됩니다.
   - 검정색 아이템을 획득하면 문양이 생성되지 않으며 플레이어의 문양 획득을 방해한다.

<br>

***
  
### 3. 적 및 스테이지
<table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/fd51ec1f-1fc4-41b3-b7fa-88913c565570"></a></td>
  </tr>
</table>

   - 보스는 정중앙에 위치합니다.
   - 보스는 항상 플레이어의 위치를 추적하여 공격합니다.

<br>

<table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/cc0aec70-31fc-4d32-9565-aab67439961d"></a></td>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/e95fae04-c656-4b2b-aeb0-451728f25794"></a></td>
  </tr>
</table>
<table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/df35b446-a3ef-4a34-bd29-9c28b948663f"></a></td>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/89c198d9-087e-43ac-9916-199c7866cd41"></a></td>
  </tr>
</table>

   - 보스는 랜덤으로 검기 공격, 길로틴 공격, 밀쳐내기, 당기기를 일정 간격으로 시전합니다.

<br>

   <table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/9536bdc2-ad71-4356-adfc-d7136bade461"></a></td>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/bfe46e65-330d-4932-ac3f-89a9c8d3c839"></a></td>
  </tr>
</table>

<div align="center">

<table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/ad5f3826-f1c1-45a9-9c9b-ff7b69d0a0be"></a></td>
  </tr>
</table>

</div>

   - 특정 체력에 도달하면 OX Phase에 돌입합니다. 플레이어는 발 밑의 문양과 머리위의 문양이 일치해야하며, 동시에 안전구역으로 이동해야합니다. 

<br>

***
        
### 4. Sound 효과
   - 게임 진행 동안 로스트아크 BGM을 감상할 수 있으며, 플레이어가 취향껏 변경할 수 있습니다.  
   - 보스의 공격에 효과음이 있어 게임의 몰입감을 높여줍니다.

<br>

***
        
### 5. UI

<div align="center">

<table>

  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/d4063991-4a7d-45e7-9706-418f2b10ac02"></a></td>
  </tr>
</table>

</div>

   - Setting UI를 활성화하면 오디오를 설정할 수 있습니다.

<br>

<div align="center">

<table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/db76d300-fd3b-4503-a1c7-661487524697"></a></td>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/c0996bca-df3f-426a-98cd-e54174c6860f"></a></td>
  </tr>
</table>

</div>

   - Slider바를 통해 배경음악, 효과음 볼륨을 각각 조절 할 수 있습니다.
   - Toggle을 이용해 배경음악, 효과음을 가각 뮤트 할 수 있습니다.

<br>

<div align="center">

<table>
  <tr>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/90c6c96c-6071-4bf0-85b2-4a75e90365fe"></a></td>
    <td><a href=""><img src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/cf991d1a-4f08-45b9-a96e-72e367699a00"></a></td>
  </tr>
</table>

</div>

   - 일괄 설정을 통해 배경음악, 효과음 볼륨을 동시에 조절할 수 있습니다.
   - 배경 음악 변경을 통해 플레이어가 원하는 배경음악으로 변경할 수 있습니다.

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>

## :timer_clock: 프로젝트 수행 절차

| 구분 | 기간 | 활동 | 비고 |
| :---: | :---: | :---: | :---: |
| 사전 기획 | 06.03(월) | 코드 컨벤션, 협업 툴, 프로젝트 게임 선정 | 퍼즐 게임 |
| 게임 기획 | 06.03(월) ~ 06.10(월) | 구현 목표 선정, 작업 환경 조율 |
| 프레임 워크 | 06.03(월) ~ 06.03(월) | 와이어 프레임 제작 | Figma |
| 기능 구현 | 06.03(월) ~ 06.10(월) | 프로젝트 기능 구현 코딩 및 유니티 작업 |
| 에셋 수집 | 06.03(월) ~ 06.07(금) | UI 및 보스, 사운드 작업용 에셋 수집 |
| 게임 구축 | 06.07(금) ~ 06.10(월) | 사운드 적용 및 기능 오류 수정, 코드 리팩토링 |

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>

## :joystick: 기술 스택

| 기술스택 | 사용이유 | 결과 |
| :---: | :---: | :---: |
| Object Pool | 반복적으로 생성되고 파괴될 오브젝트의 연산을 줄이기 위해 사용 | 자주 생성되는 객체를 미리 생성하여 Instatiate, Destroy에 사용되는 리소스 절약 |
| 옵저버 패턴 | 다양한 객체에서 동시에 다양한 역할들을 수행하기 위해서 사용 | event, action을 통해 특정 상황에서 Call 할 경우 해당 OnEvent에 구독된 모든 이벤트들이 실행됨 |
| 싱글톤 | StartScene에서 설정된 설정값들을 MainScene에 가져가기 위함 | StartScene에서 설정한 음향값들이 MainScene으로 그대로 넘어감 |
| InputSystem | 다양한 input 값들에 직접 event를 등록하여 키 입력의 확장성을 확보 | 우클릭 : 이동, 스페이스바 : 슬라이드 기능 구현; 키 추가 및 변경에 대한 확장성 확보 |

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>

## :spider_web: 와이어프레임

![image](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/b10b7b8f-b7f1-4dab-bb09-cafcbf750132)

<br>

![image](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/33a2f636-609a-4e5c-aa57-22182648076b)

<br>

![MainScene 1번 기믹](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/11ff3684-d993-42a7-bb3e-00d2e9f8a41f)

<br>

![MainScene X자 기믹](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/c3fff0b8-9ec0-4def-97b3-3c8c1aea66c9)

<br>

![MainScene 십자 기믹](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/54ba0e74-92e3-4a57-aad6-0a7afb042806)

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>

## :notebook: UML

<img width="6336" alt="UML" src="https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/d2fbfc96-a178-4b38-b7a9-d6d7940068df">

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>

## :ballot_box_with_check: 트러블 슈팅

![트러블슈팅 1 1](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/df689642-d9ae-4c34-9a2f-418d634d18db)

<br>

![트러블슈팅 1 2](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/f9812d65-1841-4b19-ae78-4c1a43b9bded)

<br>

![트러블슈팅 2 1](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/0d71b907-9d92-4613-8ba5-eb125a3ef6e6)

<br>

![트러블슈팅 2 2](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/eb46b4b2-4d1b-401e-972e-19a0ff77d92c)

<br>

![트러블슈팅 3](https://github.com/LuBly/LuBly-Sparta-Week4-3DGame-TeamProject/assets/154639213/8e92c860-2bea-4033-84a0-0ffc5ff7a151)

<br>

[:ringed_planet: 목차로 돌아가기](#목차)

<br><br>



## 프로젝트 구조
![image](https://github.com/LuBly/Sparta-Week4-3DGame-TeamProject-Abrelshu/assets/48556414/632f5e51-d69e-44cb-aec7-baddb7895485)
