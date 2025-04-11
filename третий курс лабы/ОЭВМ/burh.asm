RD #390
WR R0
RD #403
WR R1
CALL BIN
RD #391
WR R0
RD #413
WR R1
CALL BIN
RD #403
WR R0
RD #435
WR R1
CALL Intermediate
RD #413
WR R0
RD #455
WR R1
CALL Intermediate
RD #0
WR R9
IN
JZ ZeroInput
JNS PositiveInput
JS NegativeInput
ZeroInput: 
   RD #460
   WR R0
   RD #420
   WR R1
   RD #440
   WR R2
   CALL NQ
   JMP OutputPhase
PositiveInput: 
   RD #420
   WR R0
   CALL DK
   RD #440
   WR R0
   CALL DK
   RD #475
   WR R0
   RD #435
   WR R1
   RD #455
   WR R2
   CALL SUM
   RD #460
   WR R0
   CALL DK
   JMP OutputPhase
NegativeInput:
   RD #440
   WR R0
   RD #1
   SUB @R0
   WR @R0
   JMP PositiveInput
OutputPhase:
   RD 475
   JNZ OutputPhase_1
   RD #1
   WR R9
   OutputPhase_1:
   RD #460
   WR R0
   RD #480
   WR R1
   CALL OUTPUT
   RD #475
   WR R0
   RD #490
   WR R1
   CALL DEC
   OUT
   HLT 
Intermediate:   
   RD #4
   WR R2
   I1: 
       RD @R0
       WR R3
       RD #4
       WR R4
       RD #1
       WR R5
       I2: RD R3
           DIV R5
           I21: 
                SUB #100
           JNS I21
           ADD #100
           I22: 
                SUB #10
           JNS I22
           ADD #10
           WR @R1
           RD R1
           SUB #1
           WR R1
           RD R5
           MUL #10
           WR R5
           RD R4
           SUB #1
           WR R4
           JNZ I2
       RD R0
       SUB #1
       WR R0
       RD R2
       SUB #1
       WR R2
       JNZ I1
   RET
DK: 
    RD #15
    WR R1
    RD @R0
    WR R2
    JZ DK_OUT
    DK1: 
         RD R1
         SUB #1
         WR R1
       
         RD R0
         ADD #1
         WR R0

         RD #1
         SUB @R0
         WR @R0

         RD R1
         JNZ DK1
    
    RD #16
    WR R1
    DK2: 
         RD @R0
         JNZ DK21
         RD #1
         WR @R0
         RD #0
         WR R2
         JMP DK22
         DK21: 
               RD #0
               WR @R0
         DK22: 
               RD R0
               SUB #1
               WR R0
               RD R1
               SUB #1
               WR R1
               JZ DK_OUT
               RD R2
               JZ DK_OUT
               JMP DK2
    DK_OUT: 
            RD R2
            JZ DK_OUT1
            RD #1
            WR R8
            DK_OUT1:
                     RET
SUM: 
     RD #16
     WR R3

     RD #0
     WR R6

     SUM1: 
           RD @R1
           ADD @R2
           ADD R6
           WR R4
           DIV #2
           MUL #2
           WR R5
           RD R4
           SUB R5
           WR @R0
           RD R5
           DIV #2
           WR R6
            
           RD R0
           SUB #1
           WR R0
           RD R1
           SUB #1
           WR R1
           RD R2
           SUB #1
           WR R2
           RD R3
           SUB #1
           WR R3

           RD R3
           JZ SUM_OUT              
           RD #1
           WR R8
           JMP SUM1
     
     SUM_OUT: 
              RD R1
              ADD #1
              WR R1
              RD R2
              ADD #1
              WR R2
              RD R0
              ADD #1
              WR R0

              RD @R1
              ADD @R2
              WR R7
              SUB #1
              JZ SUM_OUT1
              ADD @R0
              JS SUM_OUT1
              SUB #2
              JZ SUM_OUT1
              SUM_OUT1:
                       RET
NQ: 
    RD #16
    WR R3
    NQ1: 
         RD @R1
         SUB @R2
         JZ ONE
         RD #0
         JMP NQ11
         ONE:
         RD @R1
         NQ11: 
         WR @R0
         RD R0
         ADD #1
         WR R0
         RD R1
         ADD #1
         WR R1
         RD R2
         ADD #1
         WR R2
         RD R3
         SUB #1
         WR R3
         JZ NQ_OUT
         JMP NQ1
    NQ_OUT:
            RET
OUTPUT:
        RD #4
        WR R2
        OUTPUT_1: 
                  RD #4
                  WR R3
                  RD #0
                  WR @R1
                  OUTPUT_2:
                            RD @R1
                            MUL #10
                            ADD @R0
                            WR @R1
                            JZ OUTPUT_3
                            OUTPUT_3: 
                            RD R0
                            ADD #1
                            WR R0
                            RD R3
                            SUB #1
                            WR R3
                  JNZ OUTPUT_2
                  RD R1
                  ADD #1
                  WR R1
                  RD R2
                  SUB #1
                  WR R2
        JNZ OUTPUT_1
        RET
BIN:
     RD #4
     WR R2
     RD @R0
     WR R7
     JNS BIN_1
     RD #1
     WR R4
     RD #0
     SUB #1
     MUL R7
     WR R7
     BIN_1:
           RD #4
           WR R3
           RD #1
           WR R5
           RD #0
           WR @R1
           BIN_2:
                 RD R7
                 DIV #2
                 MUL #2
                 WR R6
                 RD R7
                 SUB R6
                 MUL R5
                 ADD @R1
                 WR @R1
                 RD R7
                 DIV #2
                 WR R7
                 RD R5
                 MUL #10
                 WR R5
                 RD R3
                 SUB #1
                 WR R3
           JNZ BIN_2
           RD R1
           SUB #1
           WR R1
           RD R2
           SUB #1
           WR R2
    JNZ BIN_1
    RD R4
    JZ BIN_OUT
                RD R5
                DIV #10
                WR R5
                RD R1
                ADD #1
                WR R1
                RD @R1
                ADD R5
                WR @R1
    BIN_OUT:
             RD R7
             JZ BIN_OUT_1
             RD #1
             WR R8
BIN_OUT_1:
RET
DEC:
RD #15
WR R2
RD #0
WR @R1
RD #1
WR R3
DEC_1: 
RD @R0
MUL R3
ADD @R1
WR @R1
JZ DEC_2
DEC_2: 
RD R3
MUL #2
WR R3
RD R0
SUB #1
WR R0
RD R2
SUB #1
WR R2
JNZ DEC_1
RD @R0
JZ DEC_3
RD #0
SUB #1
MUL @R1
WR @R1
DEC_3:
RET